using System;
using System.Collections.Generic;

namespace UWBLocationMonitor
{
    public class LocationMapPanel : Panel
    {
        public LocationMapPanel()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.DoubleBuffered = true; // Prevent flickering

            TagManager.Instance.TagsUpdated += HandleTagsUpdated;
        }

        private void HandleTagsUpdated()
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTags(e.Graphics);
        }

        private void DrawTags(Graphics g)
        {
            var tags = TagManager.Instance.GetTags();
            foreach (var tag in tags)
            {
                DrawTag(g, tag);
            }
        }

        private void DrawTag(Graphics g, Tag tag)
        {
            using (Brush brush = new SolidBrush(Color.Pink))
            {
                int diameter = 10;
                int radius = diameter / 2;
                int x = tag.tagX - radius;
                int y = tag.tagY - radius;

                g.FillEllipse(brush, (x / 2) + 350, y / 2, diameter, diameter);

                using (Font font = new Font("Arial", 8))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    // Position of the text for the tagID
                    g.DrawString(tag.tagID, font, Brushes.Black, (tag.tagX / 2) + 350, (tag.tagY + diameter) / 2, sf);
                }
            }
        }
    }
}
