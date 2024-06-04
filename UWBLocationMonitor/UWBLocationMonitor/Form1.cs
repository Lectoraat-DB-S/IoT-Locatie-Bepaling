namespace UWBLocationMonitor
{
    public partial class Form1 : Form
    {
        private LogPanel logPanelInstance;
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            SetupCustomPanels();

            this.MinimumSize = new Size(800, 600);

            TagManager.Instance.SetUIControl(this);

            NetworkConnection networkConnection = new NetworkConnection("145.44.116.114", 8080);
            networkConnection.StartListening();
            // Dummy data for debugging
            //TagManager.Instance.UpdateTagTrilateration("001", 0, 0, 100, 500, 0, 300, 0, 500, 400);
            //TagManager.Instance.UpdateTagTrilateration("002", 0, 0, 250, 500, 0, 450, 0, 500, 100);
            TagManager.Instance.UpdateTag("Anchor1", 420, 1500);
            TagManager.Instance.UpdateTag("Anchor2", 420, 0);
            TagManager.Instance.UpdateTag("Anchor3", 0, 0);
        }

        private void SetupCustomPanels()
        {
            //Setup for map panel
            LocationMapPanel locationMapPanel = new LocationMapPanel();
            locationMapPanel.Dock = DockStyle.Fill; // Fill the panel
            this.splitContainer1.Panel1.Controls.Add(locationMapPanel);

            //Setup for detail panel
            LocationDetailsPanel locationDetailsPanel = new LocationDetailsPanel();
            locationDetailsPanel.Dock = DockStyle.Fill; // Fill the panel
            this.splitContainer1.Panel2.Controls.Add(locationDetailsPanel);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logButton_Click(object sender, EventArgs e)
        {
            if (logPanelInstance == null || logPanelInstance.IsDisposed)
            {
                logPanelInstance = new LogPanel();
            }
            logPanelInstance.Show();
            logPanelInstance.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LogManager.Log("This is a test log message.");

            //TagManager.Instance.UpdateTagTrilateration("002", 0, 0, 6.5, 10, 0, 4.8, 0, 10, 2.7);

            //LocationService.CalculateTagPos(0, 0, 6.5, 10, 0, 4.8, 0, 10, 2.7, "Tag1");
        }
    }
}