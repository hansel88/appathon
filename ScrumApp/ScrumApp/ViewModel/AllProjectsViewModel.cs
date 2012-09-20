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
    public class AllProjectsViewModel : ViewModelBase
    {
        public AllProjectsViewModel(ProjectController ctrl = null)
        {
            this.ctrl = (ctrl != null ? ctrl : new ProjectController());
            Projects = DataStructure.Projects;
        }

        private ProjectController ctrl;

        private List<Project> _projects;
        public List<Project> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                onPropertyChanged("Projects");
            }
        }
    }
}
