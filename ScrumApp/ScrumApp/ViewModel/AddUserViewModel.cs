using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;
using SharedResources.Model;
using SharedResources.Controller;

namespace ScrumApp.ViewModel
{
    public class AddUserViewModel : ViewModelBase
    {
        private UserController ctrl;

        public AddUserViewModel(UserController ctrl = null)
        {
            this.ctrl = (ctrl != null ? ctrl : new UserController());
        }

        public void SaveUser(User user)
        {
            ctrl.RegisterUser(user);
        }
    }
}
