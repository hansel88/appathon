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
            // Fetching the settings
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

            // Saving the settings temporarily in the app
            DataStructure.Projects = roamingSettings.Values["Projects"] as List<Project>;
        }

        public static void SaveData()
        { 
            // Fetching the settings
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

            // Saving the settings in the cloud
            roamingSettings.Values["Projects"] = DataStructure.Projects;
        }

        public void InitHandlers()
        {
            ApplicationData.Current.DataChanged +=
               new TypedEventHandler<ApplicationData, object>(DataChangeHandler);
        }

        private void DataChangeHandler(ApplicationData data, object o)
        { 
            // Refresh data here!
            LoadData();
        }


    }
}
