namespace UWBLocationMonitor
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
            buttonPanel = new Panel();
            splitContainer1 = new SplitContainer();
            TestLabel = new Label();
            logButton = new Button();
            buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(logButton);
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1184, 29);
            buttonPanel.TabIndex = 0;
            buttonPanel.Paint += panel1_Paint;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 29);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TestLabel);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1184, 732);
            splitContainer1.SplitterDistance = 844;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // TestLabel
            // 
            TestLabel.AutoSize = true;
            TestLabel.Location = new Point(302, 240);
            TestLabel.Name = "TestLabel";
            TestLabel.Size = new Size(92, 15);
            TestLabel.TabIndex = 0;
            TestLabel.Text = "Label for testing";
            TestLabel.Click += label1_Click;
            // 
            // logButton
            // 
            logButton.Location = new Point(3, 3);
            logButton.Name = "logButton";
            logButton.Size = new Size(75, 23);
            logButton.TabIndex = 0;
            logButton.Text = "Log";
            logButton.UseVisualStyleBackColor = true;
            logButton.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 761);
            Controls.Add(splitContainer1);
            Controls.Add(buttonPanel);
            Name = "Form1";
            Text = "Form1";
            buttonPanel.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel buttonPanel;
        private SplitContainer splitContainer1;
        private Label TestLabel;
        private Button logButton;
    }
}