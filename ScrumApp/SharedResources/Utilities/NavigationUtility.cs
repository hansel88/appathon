using System;
using System.Net;
using System.Windows;
using Windows.UI.Xaml;


namespace SharedResources.Utilities
{
    public static class NavigationUtility
    {
        private static object _PassedObject = null;
        public static object PassedObject
        {
            get
            {
                var obj = _PassedObject;
                _PassedObject = null;
                return obj;
            }
        }

        public static void NavigateTo(object target)
        {
            Uri uri = null;
          
            if (uri != null && target != null)
            {
                (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);
            }
        }
    }
}
