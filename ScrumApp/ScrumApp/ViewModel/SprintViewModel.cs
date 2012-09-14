using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumApp.ViewModel;
using SharedResources.Model;

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

        public SprintViewModel()
        {

        }
    }
}
