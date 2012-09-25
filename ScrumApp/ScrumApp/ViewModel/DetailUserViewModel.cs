using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    class DetailUserViewModel : ViewModelBase
    {
        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                onPropertyChanged("User");
            }
        }

        public DetailUserViewModel()
        {
            User = new User();

            // TEMP DATA
            User.RealName = "Kristofer Selbekk";
            User.UserName = "Selbeezy";
            User.Email = "Selbeezy@gmail.com";
            User.PhoneNumber = "92673134";
            User.AccessLevel = PermissionLevel.AdminOnly;
        }
    }
}
