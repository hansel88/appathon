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
    public class StoryStateChange : ModelBase
    {
        private DateTime _timeStamp;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
