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
        public static List<User> Users { get; set; }

        public static Project CurrentProject { get; set; }
        public static User CurrentUser { get; set; }

        #endregion

        // Methods that deals with finding and / or editing these projects
    }
}
