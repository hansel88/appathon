using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Controller;
using SharedResources.Model;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    public class ProjectViewModel : ViewModelBase
    {
        public ProjectViewModel(ProjectController ctrl = null)
        {
            this.ctrl = (ctrl != null ? ctrl : new ProjectController());
        }

        private ProjectController ctrl;

        private Project _currentProject;
        public Project CurrentProject
        {
            get
            {
                return _currentProject;
            }
            set
            {
                _currentProject = value;
                onPropertyChanged("CurrentProject");
                onPropertyChanged("PageTitle");
            }
        }

        public List<User> Users
        {
            get
            {
                return DataStructure.Users;
            }
        }

        public string PageTitle
        {
            get
            {
                if (CurrentProject != null)
                {
                    return "Overview - " + CurrentProject.Name;
                }
                else
                {
                    return "Project was not found";
                }
            }
        }

        public string StartAndEndDates
        {
            get
            {
                if (CurrentProject != null)
                {
                    return CurrentProject.StartDate.ToString("d") + " - " + CurrentProject.EndDate.ToString("d");
                }
                else
                {
                    return "Dates unknown";
                }
            }
        }
    }
}
