namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.MessageForm = new System.Windows.Forms.Label();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.Test2Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.MessageForm);
            this.panel1.Location = new System.Drawing.Point(1505, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 912);
            this.panel1.TabIndex = 1;
            // 
            // MessageForm
            // 
            this.MessageForm.AutoSize = true;
            this.MessageForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageForm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MessageForm.Location = new System.Drawing.Point(13, 10);
            this.MessageForm.Name = "MessageForm";
            this.MessageForm.Size = new System.Drawing.Size(36, 17);
            this.MessageForm.TabIndex = 0;
            this.MessageForm.Text = "Log:";
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLogButton.Location = new System.Drawing.Point(1752, 930);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(140, 51);
            this.ClearLogButton.TabIndex = 1;
            this.ClearLogButton.Text = "Cleal Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(12, 987);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(1880, 33);
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Progress.TabIndex = 2;
            // 
            // Picture
            // 
            this.Picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Picture.Location = new System.Drawing.Point(12, 22);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(1463, 902);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 3;
            this.Picture.TabStop = false;
            // 
            // TestButton
            // 
            this.TestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestButton.Location = new System.Drawing.Point(1335, 930);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(140, 51);
            this.TestButton.TabIndex = 6;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // Test2Button
            // 
            this.Test2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Test2Button.Location = new System.Drawing.Point(1189, 930);
            this.Test2Button.Name = "Test2Button";
            this.Test2Button.Size = new System.Drawing.Size(140, 51);
            this.Test2Button.TabIndex = 7;
            this.Test2Button.Text = "Test2";
            this.Test2Button.UseVisualStyleBackColor = true;
            this.Test2Button.Click += new System.EventHandler(this.Test2Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Test2Button);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MessageForm;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Button TestButton;
        public System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.Button Test2Button;
    }
}

