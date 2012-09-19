using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScrumApp.ViewModel;
using SharedResources.Model;
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
    public sealed partial class AddProjectView : ScrumApp.Common.LayoutAwarePage
    {
        public AddProjectView()
        {
            this.InitializeComponent();

            vm = new AddProjectViewModel();

            dtpStartButton.MinValue = DateTime.Now;
            dtpEndButton.MinValue = DateTime.Now;
        }

        private AddProjectViewModel vm;

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

        private void SaveProject(object sender, RoutedEventArgs e)
        {
            if (!IsValid())
            {
                errText.Text = App.Current.Resources["errRequiredFieldsEmpty"] as String;
                errText.Visibility = Visibility.Visible;
                return;
            }

            Project project = new Project();
            project.Name = txtName.Text;
            project.Description = txtDescription.Text;
            project.StartDate = dtpStartButton.Value ?? DateTime.Now;
            project.EndDate = dtpEndButton.Value ?? DateTime.Now;

            project = vm.SaveProject(project);
            if (project != null)
            {
                this.Frame.Navigate(typeof(ProjectView), project);
            }
            else
            {
                errText.Text = App.Current.Resources["errGeneralError"] as String;
                errText.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            errText.Visibility = Visibility.Collapsed;
        }

        private void StartDateSet(object sender, EventArgs e)
        {
            dtpEndButton.IsEnabled = true;
            dtpEndButton.MinValue = dtpStartButton.Value ?? DateTime.Now;
            dtpEndButton.Value = dtpStartButton.Value ?? DateTime.Now;
        }

        private bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(txtName.Text) && 
                    !String.IsNullOrWhiteSpace(txtDescription.Text) && 
                    dtpStartButton.Value != null && 
                    dtpEndButton.Value != null);
        }
    }
}
