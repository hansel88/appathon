using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ScrumApp.ViewModel;
using System.Text.RegularExpressions;
using SharedResources.Utilities;
using SharedResources.Model;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AddUserView : ScrumApp.Common.LayoutAwarePage
    {
        private AddUserViewModel vm;

        public AddUserView()
        {
            this.InitializeComponent();
            vm = new AddUserViewModel();
        }

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

        private void SaveAndAddAnother(object sender, RoutedEventArgs e)
        {
            if (SaveUser())
            {
                // clear fields, everything went OK
                clearErrorText();
                clearFields();
            }
        }

        private void SaveAndExit(object sender, RoutedEventArgs e)
        {
            if (SaveUser())
            {
                this.Frame.GoBack();
            }
        }

        private bool SaveUser()
        {
            if (!IsValid())
            {
                setError(App.Current.Resources["errRequiredFieldsEmpty"] as String);
                return false;
            }

            // Checks for valid email
            if (!IsValidEmailAddress(txtEmail.Text))
            {
                setError(App.Current.Resources["errMisformedEmail"] as String);
                return false;
            }

            // Creates a User-object
            User user = new User()
            {
                RealName = txtRealName.Text,
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Password,
                PhoneNumber = txtPhone.Text,
                AccessLevel = ((PermissionBox.SelectedItem as String) == "Administrator" ? PermissionLevel.AdminOnly : PermissionLevel.UserOnly)
            };

            // Tries to register the user 
            try
            {
                vm.SaveUser(user);
                return true;
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "Username taken")
                {
                    setError("The username is already taken.");
                    return false;
                }
                else // User object is not valid.
                {
                    setError(App.Current.Resources["errGeneralError"] as String);
                    return false;
                }
            }
        }

        private bool IsValid()
        { 
            return (!String.IsNullOrWhiteSpace(txtRealName.Text) &&
                    !String.IsNullOrWhiteSpace(txtUserName.Text) &&
                    !String.IsNullOrWhiteSpace(txtEmail.Text) &&
                    !String.IsNullOrWhiteSpace(txtPhone.Text) &&
                    !String.IsNullOrWhiteSpace(txtPassword.Password));
        }

        private bool IsValidEmailAddress(string email)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email);
        }

        private void clearErrorText()
        {
            errorBox.Text = "";
            errorBox.Visibility = Visibility.Collapsed;
        }

        private void setError(string error)
        {
            errorBox.Text = error;
            errorBox.Visibility = Visibility.Visible;
        }


        private void clearFields()
        {
            txtRealName.Text = "";
            txtUserName.Text = "";
            txtPassword.Password = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private void FieldFocused(object sender, RoutedEventArgs e)
        {
            clearErrorText();
        }
    }
}
