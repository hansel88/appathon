using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumApp.ViewModel;
using SharedResources.Model;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    class SprintViewModel : ViewModelBase
    {
        private Sprint _currentSprint;
        public Sprint CurrentSprint
        {
            get
            {
                return _currentSprint;
            }
            set
            {
                _currentSprint = value;
                onPropertyChanged("CurrentSprint");
            }
        }

        private List<Story> _open;
        public List<Story> Open
        {
            get
            {
                return _open;
            }
            set
            {
                _open = value;
                onPropertyChanged("Open");
            }
        }

        private List<Story> _inAnalysis;
        public List<Story> InAnalysis
        {
            get
            {
                return _inAnalysis;
            }
            set
            {
                _inAnalysis = value;
                onPropertyChanged("InAnalysis");
            }
        }

        private List<Story> _inProgress;
        public List<Story> InProgress
        {
            get
            {
                return _inProgress;
            }
            set
            {
                _inProgress = value;
                onPropertyChanged("InProgress");
            }
        }

        private List<Story> _testing;
        public List<Story> Testing
        {
            get
            {
                return _testing;
            }
            set
            {
                _testing = value;
                onPropertyChanged("Testing");
            }
        }

        private List<Story> _closed;
        public List<Story> Closed
        {
            get
            {
                return _closed;
            }
            set
            {
                _closed = value;
                onPropertyChanged("Closed");
            }
        }

        public SprintViewModel()
        {
            Open = new List<Story>();
            InAnalysis = new List<Story>();
            InProgress = new List<Story>();
            Testing = new List<Story>();
            Closed = new List<Story>();

            if (NavigationUtility.PassedObject != null && NavigationUtility.PassedObject is Sprint)
            {
                CurrentSprint = NavigationUtility.PassedObject as Sprint;

                foreach (Story story in CurrentSprint.Stories)
                {
                    switch (story.State)
                    {
                        case StoryStates.Closed: Closed.Add(story);
                            break;
                        case StoryStates.InAnalysis: InAnalysis.Add(story);
                            break;
                        case StoryStates.InProgress: InProgress.Add(story);
                            break;
                        case StoryStates.Open: Open.Add(story);
                            break;
                        case StoryStates.Testing: Testing.Add(story);
                            break;
                        case StoryStates.Unassigned:
                            break;
                    }
                }
            }
            //// TEMPORARY DATA
            Story UserStory = new Story();
            UserStory.Description = "Random description. blablablablablablabla. blablalbllalblalbal";
            UserStory.Title = "Story number 1";

            User tempUser = new User();
            tempUser.UserName = "random username";
            tempUser.RealName = "Hans Petter Naumann";
            UserStory.Author = tempUser;
            UserStory.CreatedDate = DateTime.Now;
            UserStory.Priority = 500;

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

            UserStory.State = StoryStates.Open;
            Open.Add(UserStory);
            ///////////////////
            Story UserStory2 = new Story();
            UserStory2.Description = "Random description. blablablablablablabla. blablalbllalblalbal";
            UserStory2.Title = "Story number 2";

            User tempUser2 = new User();
            tempUser2.UserName = "random username";
            tempUser2.RealName = "Kris Selbekk";
            UserStory2.Author = tempUser;
            UserStory2.CreatedDate = DateTime.Now;
            UserStory2.Priority = 900;

            Comment c12 = new Comment();
            c12.Author = tempUser;
            c12.Text = "random comment. blabla";
            c12.TimeStamp = DateTime.Now;

            Comment c22 = new Comment();
            c22.Author = tempUser;
            c22.Text = "random comment number 2. blabla";
            c22.TimeStamp = DateTime.Now;

            UserStory2.Comments.Add(c1);
            UserStory2.Comments.Add(c2);
            UserStory2.Assignee = tempUser;

            UserStory2.State = StoryStates.InProgress;
            InProgress.Add(UserStory2);
        }
    }
}
