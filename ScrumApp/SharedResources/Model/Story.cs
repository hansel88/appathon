using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;

namespace SharedResources.Model
{
    class Story : ModelBase
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                onPropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                onPropertyChanged("Description");
            }
        }

        private int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                onPropertyChanged("Priority");
            }
        }

        private User _author;
        public User Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                onPropertyChanged("Author");
            }
        }

        private User _assignee;
        public User Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                _assignee = value;
                onPropertyChanged("Assignee");
            }
        }

        private Story _parentStory;
        public Story ParentStory
        {
            get
            {
                return _parentStory;
            }
            set
            {
                _parentStory = value;
                onPropertyChanged("ParentStory");
            }
        }

        private string[] _tags;
        public string[] Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
                onPropertyChanged("Tags");
            }
        }

        private StoryStates _state;
        public StoryStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                onPropertyChanged("State");
            }
        }
    }
}
