﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SharedResources.Model
{
    [DataContract]
    public class Project : ModelBase
    {
        private List<Sprint> _sprints = new List<Sprint>();
        [DataMember]
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

        private List<Story> _storyQueue = new List<Story>();
        [DataMember]
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
        [DataMember]
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

        private DateTime _startDate;
        [DataMember]
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
        [DataMember]
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

        private List<User> _registeredUsers = new List<User>();
        [DataMember]
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

        private User _scrumMaster;
        [DataMember]
        public User ScrumMaster
        {
            get
            {
                return _scrumMaster;
            }
            set
            {
                _scrumMaster = value;
                onPropertyChanged("ScrumMaster");
            }
        }

        private User _projectOwner;
        [DataMember]
        public User ProjectOwner
        {
            get
            {
                return _projectOwner;
            }
            set
            {
                _projectOwner = value;
                onPropertyChanged("ProjectOwner");
            }
        }

        #region Derived properties

        public string StartToEndDate
        {
            get
            {
                return StartDate.ToString("d") + " - " + EndDate.ToString("d") + " (" + (EndDate - StartDate).Days + " days)";
            }
        }

        public string CurrentStatusString
        {
            get
            {
                if (StartDate > DateTime.Now)
                {
                    TimeSpan diff = (StartDate - DateTime.Now).Add(TimeSpan.FromDays(1));

                    if (diff.Days == 1)
                        return "Starts tomorrow.";

                    string str = "Starts in ";
                    str += (diff.Days > 30 ? (diff.Days % 30) + " month" : (diff.Days + " day"));
                    if (diff.Days % 30 != 1)
                        str += "s.";

                    return str;
                }

                if (EndDate < DateTime.Now)
                {
                    TimeSpan diff = (DateTime.Now - EndDate);

                    if (diff.Days == 0)
                        return "Ended yesterday";

                    string str = "Ended ";
                    str += (diff.Days > 30 ? (diff.Days % 30) + " month" : diff.Days + " day");
                    if (diff.Days % 30 != 1)
                        str += "s ";
                    str += "ago";

                    return str;
                }

                return "Currently in progress.";
            }
        }

        #endregion
    }
}
