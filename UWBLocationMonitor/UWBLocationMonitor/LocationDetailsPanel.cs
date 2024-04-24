using System;
using System.Collections.Generic;


namespace UWBLocationMonitor
{
    public class LocationDetailsPanel : Panel
    {
        private TextBox locationInfo;
        private List<Tag> tagDetails;

        public LocationDetailsPanel()
        {
            this.BackColor = Color.White;
            //this.Size = new Size(400, 200);

            locationInfo = new TextBox();
            locationInfo.Multiline = true;
            locationInfo.ReadOnly = true;
            locationInfo.ScrollBars = ScrollBars.Vertical;
            locationInfo.Font = new Font("Monospaced", 12);

            // Use docking to fill the panel with the text box
            locationInfo.Dock = DockStyle.Fill;
            this.Controls.Add(locationInfo);

            this.BorderStyle = BorderStyle.FixedSingle;

            tagDetails = new List<Tag>();

            // Add some dummy data
            AddTag(new Tag { tagID = "001", tagX = 50, tagY = 100 });
        }

        public void AddTag(Tag tag)
        {
            tagDetails.Add(tag);
            UpdateLocation(tag.tagID, tag.tagX, tag.tagY);
        }

        public void UpdateLocation(string tagID, double x, double y)
        {
            foreach (var tag in tagDetails)
            {
                if (tag.tagID == tagID)
                {
                    tag.tagX = x;
                    tag.tagY = y;
                    break;
                }
            }

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Tag ID:        X:        Y: ");
            foreach (var tag in tagDetails)
            {
                sb.AppendFormat("Tag {0,-8} X: {1,-8} Y: {2,-8}\n", tag.tagID, tag.tagX, tag.tagY);
            }
            locationInfo.Text = sb.ToString();
        }

        public List<Tag> GetTagDetails()
        {
            return tagDetails;
        }
    }

    public class Tag
    {
        public string tagID { get; set; }
        public double tagX { get; set; }
        public double tagY { get; set; }
    }
}
