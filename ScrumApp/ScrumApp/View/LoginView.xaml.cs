using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScrumApp.ViewModel;
using SharedResources.Controller;
using SharedResources.Utilities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LoginView : ScrumApp.Common.LayoutAwarePage
    {
        public LoginView()
        {
            this.InitializeComponent();
            vm = new LoginViewModel();

            this.Loaded += LoginView_Loaded;
            
        }

        void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!vm.CanUserAccess())
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private LoginViewModel vm;

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            // Check for validity
            if (isLoginFieldsValid())
            {
                if (vm.Login(txtUsername.Text, txtPassword.Password))
                {
                    NavigationUtility.NavigateTo(typeof(MainPage), null, this.Frame);
                }
                else
                {
                    errFeedback.Text = App.Current.Resources["errInvalidLogin"] as String;
                    errFeedback.Visibility = Visibility.Visible;
                }
            }
            else
            {
                errFeedback.Text = App.Current.Resources["errRequiredFieldsEmpty"] as String;
                errFeedback.Visibility = Visibility.Visible;
            }

        }

        private bool isLoginFieldsValid()
        {
            return (!String.IsNullOrWhiteSpace(txtUsername.Text) &&
                    !String.IsNullOrWhiteSpace(txtPassword.Password));
        }

        private void fieldGotFocus(object sender, RoutedEventArgs e)
        {
            errFeedback.Text = String.Empty;
            errFeedback.Visibility = Visibility.Collapsed;
        }
    }
}
