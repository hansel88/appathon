using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;

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
        public Sprint saveSprint( Sprint sprint)
        {
            return null;
        }
    }
}
