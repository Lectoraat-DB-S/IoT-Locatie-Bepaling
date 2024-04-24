namespace UWBLocationMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            SetupCustomPanels();

            this.MinimumSize = new Size(800, 600);

            // Dummy data for debugging
            TagManager.Instance.UpdateTag("001", 100, 100);
            TagManager.Instance.UpdateTag("004", 50, 200);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}