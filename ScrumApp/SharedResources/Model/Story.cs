using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;

namespace SharedResources.Model
{
    public class Story : ModelBase
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

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
                onPropertyChanged("CreatedDate");
            }
        }

        public string FormattedCreatedDate
        {
            get
            {
                return DateUtility.FormatDate(CreatedDate);
            }
        }

        public string CreatedString
        {
            get
            {
                return "Created on "  + DateUtility.FormatDate(CreatedDate) + " by " + Author.RealName;
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
                if( _assignee != null )
                    return _assignee;

                return new User() { RealName = "Nobody assigned" };
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

        private List<StoryStateChange> _stateChanges;
        public List<StoryStateChange> StateChanges
        {
            get
            {
                return _stateChanges;
            }
            set
            {
                _stateChanges = value;
                onPropertyChanged("StateChanges");
            }
        }

        private List<Comment> _comments = new List<Comment>();
        public List<Comment> Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                onPropertyChanged("Comments");
            }
        }

        private bool _isBlocked = false;
        public bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                _isBlocked = value;
                onPropertyChanged("IsBlocked");
            }
        }
    }
}
