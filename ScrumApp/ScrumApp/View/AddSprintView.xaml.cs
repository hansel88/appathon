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
using SharedResources.Model;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AddSprintView : ScrumApp.Common.LayoutAwarePage
    {
        private AddSprintViewModel addSprintVIewModel;

        public AddSprintView()
        {
            this.InitializeComponent();
            addSprintVIewModel = new AddSprintViewModel();
            DataContext = addSprintVIewModel;
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
            var project = navigationParameter as Project;
            if (project == null)
            {
                // TODO: Error handling for missing project
            }
            else
            {
                addSprintVIewModel.ProjectToBeUpdated = project;
            }
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

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            errText.Visibility = Visibility.Collapsed;
        }

        private void StartDateSet(object sender, EventArgs e)
        {
            dtsEndButton.IsEnabled = true;
            dtsEndButton.MinValue = dtsStartButton.Value ?? DateTime.Now;
            dtsEndButton.Value = dtsStartButton.Value ?? DateTime.Now;
        }

        private void btnSaveSprint_Click_1(object sender, RoutedEventArgs e)
        {
            if ( ! IsValid() )
            {
                errText.Text = App.Current.Resources["errRequiredFieldsEmpty"] as String;
                errText.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                Sprint sprint = new Sprint();
                sprint.Title = txtTitle.Text;
                sprint.Description = txtDescription.Text;
                sprint.StartTime = dtsStartButton.Value ?? DateTime.Now;
                sprint.EndTime = dtsEndButton.Value ?? DateTime.Now;

                try
                {
                    sprint = addSprintVIewModel.saveSprint(sprint);
                    if (sprint != null)
                    {
                        this.Frame.Navigate(typeof(SprintView), sprint);
                    }
                    else
                    {
                        errText.Text = App.Current.Resources["errGeneralError"] as String;
                        errText.Visibility = Visibility.Visible;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    errText.Text = App.Current.Resources["errGeneralError"] as String;
                    errText.Visibility = Visibility.Visible;
                }
            }

        }

        private bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(txtTitle.Text) &&
                    !String.IsNullOrWhiteSpace(txtDescription.Text) &&
                    dtsStartButton.Value != null &&
                    dtsEndButton.Value != null);
        }
    
    }
}
