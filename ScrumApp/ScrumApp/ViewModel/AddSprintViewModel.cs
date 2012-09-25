using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Controller;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    class AddSprintViewModel : ViewModelBase
    {
        private Project _projectToBeUpdated;
        public Project ProjectToBeUpdated
        {
            get
            {
                return _projectToBeUpdated;
            }
            set
            {
                _projectToBeUpdated = value;
                onPropertyChanged("ProjectToBeUpdated");
            }
        }

        private ProjectController ctrl;

        public AddSprintViewModel()
        {
            ctrl = new ProjectController();
        }
        
        public Sprint saveSprint( Sprint sprint)
        {
            sprint.Author = DataStructure.CurrentUser;
            ProjectToBeUpdated.Sprints.Add(sprint);
            return sprint;
        }
    }
}
