using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;

namespace ScrumApp.ViewModel
{
    class DetailStoryViewModel : ViewModelBase
    {
        private Story  _userStory;
        public Story UserStory
        {
            get
            {
                return _userStory;
            }
            set
            {
                _userStory = value;
                onPropertyChanged("UserStory");
            }
        }

        public DetailStoryViewModel()
        {
            UserStory = new Story();
            UserStory.Description = "Random description. blablablablablablabla. blablalbllalblalbal";
            UserStory.Description
        }

    }
}
