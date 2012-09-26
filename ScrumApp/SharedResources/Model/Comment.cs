using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SharedResources.Model
{
    [DataContract]
    public class Comment : ModelBase
    {
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

        private string _text;
        [DataMember]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                onPropertyChanged("Text");
            }
        }

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

    }
}
