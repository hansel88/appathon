using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;

namespace SharedResources.Utilities
{
    public static class DataStructure
    {
        #region Data Structures

        public static List<Project> Projects { get; set; }

        private static List<User> _users = new List<User>();
        public static List<User> Users 
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }

        }

        public static Project CurrentProject { get; set; }
        public static User CurrentUser { get; set; }

        #endregion

        // Methods that deals with finding and / or editing these projects
    }
}
