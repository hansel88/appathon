using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Model
{
    public class Comment : ModelBase
    {
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

        private string _text;
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
