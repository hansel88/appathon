using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Model
{
    public class Sprint : ModelBase
    {
        private List<Story> _stories;
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
    }
}
