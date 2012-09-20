using System;
using System.Net;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        public static void NavigateTo(Type page, object objectToBePassed, Frame frame)
        {
            _PassedObject = objectToBePassed;
            frame.Navigate(page);   
        }
    }
}
