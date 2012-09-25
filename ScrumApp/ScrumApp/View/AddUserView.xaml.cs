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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AddUserView : ScrumApp.Common.LayoutAwarePage
    {
        private AddUserViewModel addUserViewModel;

        public AddUserView()
        {
            this.InitializeComponent();
            addUserViewModel = new AddUserViewModel();
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

        private void SaveAndAddAnotherBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (saveUser())
            {
                // clear fields, everything went OK
                clearErrorText();
                clearFields();
            }
        }

        private void SaveAndExitBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (saveUser())
            {
                this.Frame.GoBack();
            }
        }

        private bool saveUser()
        {
            bool ok = true;

            if (txtRealName.Text.Length == 0 || txtUserName.Text.Length == 0 || txtEmail.Text.Length == 0 || txtPhone.Text.Length == 0 || PermissionBox.SelectedItem == null)
            {
                errorBox.Text = "*Name, Username, email and permission level must be filled in.\n";
                errorBox.Visibility = Visibility.Visible;
                ok = false;
            }
            if (txtPassword.Password.Length < 5)
            {
                errorBox.Text += "*The password must at least 5 characters long.\n";
                ok = false;
            }
            if (!IsValidEmailAddress(txtEmail.Text))
            {
                errorBox.Text += "*Invalid email address.\n";
                ok = false;
            }
            if (ok)
            {
                if (DataStructure.Users.Find(u => u.UserName == txtUserName.Text) == null)
                {
                    addUserViewModel.saveUser(txtRealName.Text, txtUserName.Text, txtPassword.Password, txtEmail.Text, txtPhone.Text, PermissionBox.SelectedItem as string);
                    return true;
                }
                else
                {
                    errorBox.Text = "*This username is already taken.\n";
                    return false;
                }
            }
            else
            {
                return false;
            }

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


        private void clearFields()
        {
            txtRealName.Text = "";
            txtUserName.Text = "";
            txtPassword.Password = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}
