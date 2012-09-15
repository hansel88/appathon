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
        public static List<Project> Projects { get; set; }
        public static User CurrentUser { get; set; }
        public static Project CurrentProject { get; set; }

        // Methods that deals with finding and / or editing these projects
    }
}
