using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;
using SharedResources.Model;

namespace ScrumApp.ViewModel
{
    class AddUserViewModel : ViewModelBase
    {
        public void saveUser(string name, string userName, string password, string email, string phone, string permissionLevelString)
        {
            PermissionLevel permissionLevel = new PermissionLevel();
            switch (permissionLevelString)
            {
                case "User": permissionLevel = PermissionLevel.UserOnly; 
                    break;
                case "Administrator": permissionLevel = PermissionLevel.AdminOnly;
                    break;
                case "Open": permissionLevel = PermissionLevel.Open;
                    break;
            }

            User newUser = new User();

            newUser.RealName = name;
            newUser.UserName = userName;
            newUser.Password = password;
            newUser.Email = email;
            newUser.PhoneNumber = phone;
            newUser.AccessLevel = permissionLevel;

            DataStructure.Users.Add(newUser);
        }
    }
}
