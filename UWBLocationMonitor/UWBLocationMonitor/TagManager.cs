using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWBLocationMonitor
{
    public class TagManager
    {
        // Event to notify the UI to refresh the tag list
        public event Action TagsUpdated;

        // List of tags
        private List<Tag> tags = new List<Tag>();

        // Singleton instance to make sure there is only one instance of TagManager
        private static TagManager instance;

        private TagManager() {  }

        private LocationService locationService = new LocationService();

        public static TagManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TagManager();
                }
                return instance;
            }
        }

        // Method to add or update a tag to the list
        public void UpdateTag(string ID, int x, int y)
        {
            var tag = tags.Find(t => t.tagID == ID);
            if (tag != null)
            {
                // Tag exists, update the position
                tag.updatePosition(x, y);
            }
            else
            {
                // Tag does not exist, add a new tag
                tags.Add(new Tag(ID, x, y));
            }
            // Notify the UI to refresh the tag list
            TagsUpdated?.Invoke();
        }

        public void UpdateTagTrilateration(string ID, int x1, int y1, double r1, int x2, int y2, double r2, int x3, int y3, double r3)
        {
            var position = LocationService.CalculateTagPos(x1, y1, r1, x2, y2, r2, x3, y3, r3, ID);
            int x = (int)position.Item2;
            int y = (int)position.Item3;

            UpdateTag(ID, x, y);
        }

        // Method to get the list of tags
        public List<Tag> GetTags()
        {
            return tags;
        }
    }

    public class Tag
    {
        public string tagID { get; private set; }
        public int tagX { get; private set; }
        public int tagY { get; private set; }

        public Tag(string ID, int x, int y)
        {
            tagID = ID;
            tagX = x;
            tagY = y;
        }

        public void updatePosition(int x, int y)
        {
            tagX = x;
            tagY = y;
        }
    }

    public class LocationService
    {
        public static Tuple<string, double, double> CalculateTagPos(int x1, int y1, double r1, int x2, int y2, double r2, int x3, int y3, double r3, string ID)
        {
            double A = 2 * x2 - 2 * x1;
            double B = 2 * y2 - 2 * y1;
            double C = Math.Pow(r1, 2) - Math.Pow(r2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);
            double D = 2 * x3 - 2 * x2;
            double E = 2 * y3 - 2 * y2;
            double F = Math.Pow(r2, 2) - Math.Pow(r3, 2) - Math.Pow(x2, 2) + Math.Pow(x3, 2) - Math.Pow(y2, 2) + Math.Pow(y3, 2);
            double x = (C * E - F * B) / (E * A - B * D);
            double y = (C * D - A * F) / (B * D - A * E);
            return Tuple.Create(ID, x, y);
        }
    }
}