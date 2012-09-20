using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Utilities;

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

            //temp drit
            UserStory = new Story();
            UserStory.Description = "Random description. blablablablablablabla. blablalbllalblalbal";
            UserStory.Title = "Random Title";

            User tempUser = new User();
            tempUser.UserName = "random username";
            tempUser.RealName = "Hans Petter Naumann";
            UserStory.Author = tempUser;
            UserStory.CreatedDate = DateTime.Now;

            Comment c1 = new Comment();
            c1.Author = tempUser;
            c1.Text = "random comment. blabla";
            c1.TimeStamp = DateTime.Now;

            Comment c2 = new Comment();
            c2.Author = tempUser;
            c2.Text = "random comment number 2. blabla";
            c2.TimeStamp = DateTime.Now;

            UserStory.Comments.Add(c1);
            UserStory.Comments.Add(c2);
            UserStory.Assignee = tempUser;
        }

    }
}
