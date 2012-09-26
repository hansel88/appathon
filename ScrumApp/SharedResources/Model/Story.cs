using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;
using System.Runtime.Serialization;

namespace SharedResources.Model
{
    [DataContract]
    public class Story : ModelBase
    {
        private string _title;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        private List<StoryStateChange> _stateChanges = new List<StoryStateChange>();
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
