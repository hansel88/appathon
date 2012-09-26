using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SharedResources.Model
{
    [DataContract]
    public class Sprint : ModelBase
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

        private List<Story> _stories = new List<Story>();
        [DataMember]
        public List<Story> Stories
        {
            get
            {
                return _stories;
            }
            set
            {
                _stories = value;
                onPropertyChanged("Stories");
            }
        }

        private DateTime _startTime;
        [DataMember]
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                onPropertyChanged("StartTime");
            }
        }

        private DateTime _endTime;
        [DataMember]
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                onPropertyChanged("EndTime");
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

        public string StartAndEndDates
        {
            get
            {
                return StartTime.ToString("d") + " - " + EndTime.ToString("d");
            }
        }
    }
}
