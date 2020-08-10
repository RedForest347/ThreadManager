using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadS;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.form1 = this;
            ThreadManager.Init();
        }

        #region Click

        private void TestButton_Click(object sender, EventArgs e)
        {
            /*Thread t = new Thread(new ThreadStart(Test));
            t.IsBackground = true;
            t.Start();*/
            Test2();
        }

        private void Test2Button_Click(object sender, EventArgs e)
        {
            Test4();
        }

        #endregion Click

        void Test()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int i = 0; i < 1000; i++)
            {
                Thread t = new Thread(new ThreadStart(DDD));
                t.IsBackground = true;
                t.Start();
            }
            Debug.Log("on " + time.ElapsedMilliseconds / 1000f);
        }

        void Test2()
        {
            Stopwatch time = Stopwatch.StartNew();
            for (int j = 0; j < 1; j++)
            {
                ThreadManager.StartThread(new ThreadSStart(DDD));
            }

            while (ThreadManager.ShowNumOfTasks() != 0)
            {
                ThreadManager.Update();
            }

            Debug.Log("on " + time.ElapsedTicks / 1000f);
        }

        void Test3()
        {
            Stopwatch time = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                Task task = new Task(DDD);
                task.Start();
            }
            Debug.Log("d = " + d + " on time = " + time.ElapsedMilliseconds);
        }

        void Test4()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int j = 0; j < 100000; j++)
            {
                ThreadManager.StartControlledThread(new ThreadSStart(DDD));
            }

            while (ThreadManager.ShowNumOfTasks() != 0)
            {
                ThreadManager.Update();
            }

            Debug.Log("on " + time.ElapsedMilliseconds / 1000f);
        }

        static int d = 0;
        void DDD()
        {

        }

        void DDD(object o)
        {
            //Debug.Log("ура, я работаю " + o);
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            Debug.ClearLog();
        }

        #region ForDebugLog

        delegate void WriteLogDelegate(string text);
        delegate void ClearLogDelegate();
        delegate void ProgressDelegate(int value);       

        public void WriteMassage(string text)
        {
            WriteLogDelegate writeLogDelegate = new WriteLogDelegate(writeMassage);
            Invoke(writeLogDelegate, new object[] { text });
        }

        void writeMassage(string text)
        {
            MessageForm.Text += "\n" + text + "\n";
        }

        public void ClearLog()
        {
            ClearLogDelegate clearLogDelegate = new ClearLogDelegate(clearLog);
            Invoke(clearLogDelegate);
        }

        void clearLog()
        {
            MessageForm.Text = "Log: ";
        }

        public void ProgressMaxValue(int value)
        {
            ProgressDelegate progressDelegate = new ProgressDelegate(progressMaxValue);
            Invoke(progressDelegate, new object[] { value });
        }

        void progressMaxValue(int value)
        {
            Progress.Maximum = value;
        }

        public void ProgressCurrentValue(int value)
        {
            ProgressDelegate progressDelegate = new ProgressDelegate(progressCurrentValue);
            Invoke(progressDelegate, new object[] { value });
        }

        void progressCurrentValue(int value)
        {
            Progress.Value = value;
        }

        public void ProgressChengeCurrentValue(int value)
        {
            ProgressDelegate progressDelegate = new ProgressDelegate(progressChengeCurrentValue);
            Invoke(progressDelegate, new object[] { value });
        }

        void progressChengeCurrentValue(int value)
        {
            Progress.Value += value;
        }


        #endregion ForDebugLog

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
