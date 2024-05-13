using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UWBLocationMonitor
{
    public partial class LogPanel : Form
    {
        private RichTextBox richTextBox;
        public LogPanel()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.MinimumSize = new Size(800, 600);

            InitializeComponent();
            InitializeLoggingComponents();

            PopulateLogs();
            LogManager.OnLogUpdate += AppendLog;

            this.FormClosing += LogPanel_FormClosing;
        }

        private void LogPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void InitializeLoggingComponents()
        {
            richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.Black,
                ForeColor = Color.Lime,
                Font = new Font("Consolas", 10),
                ScrollBars = RichTextBoxScrollBars.ForcedVertical
            };
            this.Controls.Add(richTextBox);

            printLogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void LogPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogManager.OnLogUpdate += AppendLog;
        }

        private void PopulateLogs()
        {
            foreach (var message in LogManager.GetLogMessages())
            {
                richTextBox.AppendText(message + Environment.NewLine);
            }
        }

        public void AppendLog(string message)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<string>(AppendLog), new object[] { message } );
            }
            else
            {
                richTextBox.AppendText(message + Environment.NewLine);
                richTextBox.ScrollToCaret();
            }
        }

        private void DetachEventHandlers()
        {
            LogManager.OnLogUpdate -= AppendLog;
        }

        private void DisposePanel()
        {
            DetachEventHandlers();
            this.Dispose();
        }

        private void printLogButton_Click(object sender, EventArgs e)
        {
            LogManager.printLogToCSV();
        }
    }
}
