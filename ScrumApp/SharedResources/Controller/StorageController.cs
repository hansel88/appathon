using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Model;
using SharedResources.Utilities;
using Windows.Foundation;
using Windows.Storage;

namespace SharedResources.Controller
{
    public static class StorageController
    {
        /* 
         * This class handles all saving and loading of information
         */

        public static void LoadData()
        {
            /*
            // Fetching the settings
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

            // Saving the settings temporarily in the app
            DataStructure.Projects = roamingSettings.Values["Projects"] as List<Project> ?? new List<Project>();
            DataStructure.Users = roamingSettings.Values["Users"] as List<User> ?? new List<User>();
            */

            // Fetching the settings
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            // Saving the settings temporarily inside the app's data store
            DataStructure.Projects = localSettings.Values["Projects"] as List<Project> ?? new List<Project>();
            DataStructure.Users = localSettings.Values["Users"] as List<User> ?? new List<User>();

        }

        public static void SaveData()
        { 
            /*
            // Fetching the settings
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

            // Saving the settings in the cloud
            roamingSettings.Values["Projects"] = DataStructure.Projects;
            roamingSettings.Values["Users"] = DataStructure.Users;
             */

            // Fetching the settings
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            // Saving the settings to the permanent data store
            localSettings.Values["Projects"] = DataStructure.Projects;
            localSettings.Values["Users"] = DataStructure.Users;

        }

        public static void InitHandlers()
        {
            ApplicationData.Current.DataChanged +=
               new TypedEventHandler<ApplicationData, object>(DataChangeHandler);
        }

        private static void DataChangeHandler(ApplicationData data, object o)
        { 
            // Refresh data here!
            LoadData();
        }


    }
}
