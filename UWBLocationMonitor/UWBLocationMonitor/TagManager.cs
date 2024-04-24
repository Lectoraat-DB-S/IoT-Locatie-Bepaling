using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWBLocationMonitor
{
    public class TagManager
    {
        // List of tags
        private List<Tag> tags = new List<Tag>();

        // Singleton instance to make sure there is only one instance of TagManager
        private static TagManager instance;
        
        // Event to notify the UI to refresh the tag list
        public event Action TagsUpdated;

        private TagManager() {  }

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
        public void UpdateTag(string ID, double x, double y)
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

        // Method to get the list of tags
        public List<Tag> GetTags()
        {
            return tags;
        }
    }

    public class Tag
    {
        public string tagID { get; private set; }
        public double tagX { get; private set; }
        public double tagY { get; private set; }

        public Tag(string ID, double x, double y)
        {
            tagID = ID;
            tagX = x;
            tagY = y;
        }

        public void updatePosition(double x, double y)
        {
            tagX = x;
            tagY = y;
        }
    }
}
