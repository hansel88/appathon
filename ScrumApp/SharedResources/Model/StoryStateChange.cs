using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;

namespace SharedResources.Model
{
    public class StoryStateChange : ModelBase
    {
        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get
            {
                return _timeStamp;
            }
            set
            {
                _timeStamp = value;
                onPropertyChanged("TimeStamp");
            }
        }

        private StoryStates _oldState;
        public StoryStates OldState
        {
            get
            {
                return _oldState;
            }
            set
            {
                _oldState = value;
                onPropertyChanged("OldState");
            }
        }

        private StoryStates _newState;
        public StoryStates NewState
        {
            get
            {
                return _newState;
            }
            set
            {
                _newState = value;
                onPropertyChanged("NewState");
            }
        }

        private User _oldAsignee;
        public User OldAsignee
        {
            get
            {
                return _oldAsignee;
            }
            set
            {
                _oldAsignee = value;
                onPropertyChanged("OldAsignee");
            }
        }

        private User _newAsignee;
        public User NewAsignee
        {
            get
            {
                return _newAsignee;
            }
            set
            {
                _newAsignee = value;
                onPropertyChanged("NewAsignee");
            }
        }

        

    }
}
