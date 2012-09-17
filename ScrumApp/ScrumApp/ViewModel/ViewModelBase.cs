using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SharedResources.Utilities;

namespace ScrumApp.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void onPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _IsLoading = true;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
            set
            {
                _IsLoading = value;
                onPropertyChanged("IsLoading");
                onPropertyChanged("IsLoaded");
            }
        }

        public bool IsLoaded
        {
            get
            {
                return !IsLoading;
            }
        }

        private bool _IsOffline = false;
        public bool IsOffline
        {
            get
            {
                return _IsOffline;
            }
            set
            {
                _IsOffline = value;
                onPropertyChanged("IsOffline");
            }
        }

        public PermissionLevel AccessLevel = PermissionLevel.Open;

        public bool CanUserAccess()
        {
            if (AccessLevel != PermissionLevel.Open)
            {
                if (DataStructure.CurrentUser != null)
                {
                    return AccessLevel <= DataStructure.CurrentUser.AccessLevel;
                }
                return false;
            }
            return true;
        }
    }
}
