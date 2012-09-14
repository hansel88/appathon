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

        }
    }
}
