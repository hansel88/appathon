using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Model
{
    public class Project : ModelBase
    {
        private List<Sprint> _sprints;
        public List<Sprint> Sprints
        {
            get
            {
                return _sprints;
            }
            set
            {
                _sprints = value;
                onPropertyChanged("Sprints");
            }
        }

        private List<Story> _storyQueue;
        public List<Story> StoryQueue
        {
            get
            {
                return _storyQueue;
            }
            set
            {
                _storyQueue = value;
                onPropertyChanged("StoryQueue");
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                onPropertyChanged("Name");
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

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                onPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                onPropertyChanged("EndDate");
            }
        }

        private List<User> _registeredUsers;
        public List<User> RegisteredUsers
        {
            get
            {
                return _registeredUsers;
            }
            set
            {
                _registeredUsers = value;
                onPropertyChanged("RegisteredUsers");
            }
        }
    }
}
