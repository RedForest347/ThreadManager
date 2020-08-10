using System.Threading;
using System.Collections.Generic;

//https://docs.microsoft.com/en-us/dotnet/api/system.threading.manualresetevent?redirectedfrom=MSDN&view=netframework-4.8

namespace ThreadS
{
    public delegate void ThreadSStart();
    public delegate void ParameterizedThreadSStart(object o);

    sealed class ThreadManager
    {
        #region Options

        const int start_thread_pool_size = 50;
        const int max_thread_pool_size = 50;
        const int max_start_threads_per_update = 50;

        #endregion Options

        static int current_thread_pool_size;
        static ThreadVoid[] ThreadPool;
        static Queue<TaskContainer> Tasks;

        public static void Init()
        {
            current_thread_pool_size = 0;
            ThreadPool = new ThreadVoid[max_thread_pool_size];
            Tasks = new Queue<TaskContainer>();

            for (int id = 0; id < start_thread_pool_size; id++)
            {
                ThreadPool[id] = new ThreadVoid(id);
                current_thread_pool_size = id + 1;
            }
        }

        public static void Update()
        {
            StartTasks();
        }

        public static void StartThread(ThreadSStart threadSStart)
        {
            Tasks.Enqueue(new TaskContainer(threadSStart));
        }

        public static void StartThread(ParameterizedThreadSStart parameterizedThreadSStart, object func_param)
        {
            Tasks.Enqueue(new TaskContainer(parameterizedThreadSStart, func_param));
        }

        public static ThreadInfo StartControlledThread(ThreadSStart threadSStart)
        {
            ThreadInfo threadInfo = new ThreadInfo();
            Tasks.Enqueue(new TaskContainer(threadSStart, threadInfo));
            return threadInfo;
        }

        public static ThreadInfo StartControlledThread(ParameterizedThreadSStart parameterizedThreadSStart, object func_param)
        {
            ThreadInfo threadInfo = new ThreadInfo();
            Tasks.Enqueue(new TaskContainer(parameterizedThreadSStart, func_param, threadInfo));
            return threadInfo;
        }

        static void StartTasks()
        {
            int num_of_start_thread = 0;

            for (int i = 0; i < current_thread_pool_size; i++)
            {
                if (num_of_start_thread > max_start_threads_per_update || Tasks.Count == 0)
                    return;

                if (!ThreadPool[i].is_active)
                {
                    ThreadPool[i].Start(Tasks.Dequeue());
                    num_of_start_thread++;
                }
            }
            TryAddThread();
        }

        static void TryAddThread()
        {
            if (current_thread_pool_size < max_thread_pool_size)
            {
                ThreadPool[current_thread_pool_size] = new ThreadVoid(current_thread_pool_size);
                current_thread_pool_size++;
            }
        }

        public static int ShowNumOfTasks()
        {
            return Tasks.Count;
        }

        #region Наработки

        public void RemoveThread(int thread_id)
        {
            ThreadPool[thread_id] = null;
        }

        static void RestartMissingThreads()
        {
            for (int i = 0; i < current_thread_pool_size; i++)
            {
                if (ThreadPool[i] == null)
                    ThreadPool[i] = new ThreadVoid(i);
            }
        }

        static void RestartMissingThreads(int thread_id)
        {
            if (ThreadPool[thread_id] == null)
                ThreadPool[thread_id] = new ThreadVoid(thread_id);
        }

        #endregion


        class ThreadVoid //переименовать
        {
            public bool is_active { get; protected set; }
            public int id { get; private set; }

            private ManualResetEventSlim manualReset;
            private TaskContainer taskContainer;
            private ThreadSStart StartFunc;
            private Thread thread;
            private bool need_stop_thread;

            public ThreadVoid(int id)
            {
                manualReset = new ManualResetEventSlim(false);
                StartFunc = new ThreadSStart(ThreadStart);
                need_stop_thread = false;
                is_active = false;
                this.id = id;

                thread = new Thread(new ThreadStart(ThreadStart));
                thread.IsBackground = true;
                thread.Start();
            }

            public void Start(TaskContainer taskContainer)
            {
                is_active = true;
                this.taskContainer = taskContainer;
                manualReset.Set();
            }

            void ThreadStart()
            {
                while (!need_stop_thread)
                {
                    manualReset.Reset();
                    is_active = false;
                    manualReset.Wait();
                    taskContainer.WorkFunk();
                }
            }

            public void StopThread()
            {
                is_active = true;
                need_stop_thread = true;
                manualReset.Set();
            }

            public void Abort()
            {
                thread.Abort();
            }
        }

        struct TaskContainer
        {
            bool is_void_func;
            ThreadInfo threadInfo;
            ThreadSStart threadSStart;
            ParameterizedThreadSStart parameterizedThreadSStart;
            object o;

            public TaskContainer(ThreadSStart threadSStart, ThreadInfo threadInfo = null)
            {
                this.threadSStart = threadSStart;
                this.threadInfo = threadInfo;
                this.parameterizedThreadSStart = null;
                this.o = null;
                this.is_void_func = true;
            }

            public TaskContainer(ParameterizedThreadSStart parameterizedThreadSStart, object o, ThreadInfo threadInfo = null)
            {
                this.parameterizedThreadSStart = parameterizedThreadSStart;
                this.o = o;
                this.threadInfo = threadInfo;
                this.threadSStart = null;
                this.is_void_func = false;
            }

            public void WorkFunk()
            {
                if (threadInfo != null)
                {
                    threadInfo.is_start = true;

                    if (is_void_func)
                        threadSStart();
                    else
                        parameterizedThreadSStart(o);

                    threadInfo.is_complete = true;
                }
                else
                {
                    if (is_void_func)
                        threadSStart();
                    else
                        parameterizedThreadSStart(o);
                }
            }
        }
    }

    class ThreadInfo
    {
        public bool is_start;
        public bool is_complete;

        public ThreadInfo(bool is_start = false, bool is_complete = false)
        {
            this.is_start = false;
            this.is_complete = false;
        }
    }
}
