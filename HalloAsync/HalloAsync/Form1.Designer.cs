namespace HalloAsync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 22);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(398, 61);
            button1.TabIndex = 0;
            button1.Text = "Start ohne Thread";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(34, 165);
            progressBar1.Margin = new Padding(5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(737, 61);
            progressBar1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(430, 22);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(398, 61);
            button2.TabIndex = 2;
            button2.Text = "Start Task (Invoker)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 94);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(398, 61);
            button3.TabIndex = 3;
            button3.Text = "Start Task (TS)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(289, 236);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(281, 61);
            button4.TabIndex = 4;
            button4.Text = "Abbrechen";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(430, 94);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.Size = new Size(398, 61);
            button5.TabIndex = 5;
            button5.Text = "Async / Await";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(14, 425);
            button6.Margin = new Padding(5);
            button6.Name = "button6";
            button6.Size = new Size(398, 61);
            button6.TabIndex = 6;
            button6.Text = "Alte Function";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 500);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
