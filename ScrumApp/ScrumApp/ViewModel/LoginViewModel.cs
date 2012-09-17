using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Controller;

namespace ScrumApp.ViewModel
{
    class LoginViewModel
    {
        private UserController ctrl;

        public LoginViewModel(UserController ctrl = null)
        {
            this.ctrl = (ctrl != null ? ctrl : new UserController());
        }

        public bool Login(string username, string password)
        {
            return ctrl.Login(username, password);
        }
    }
}
