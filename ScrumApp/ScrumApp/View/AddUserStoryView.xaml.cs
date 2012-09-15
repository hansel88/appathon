using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScrumApp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
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
    public sealed partial class AddUserStoryView : ScrumApp.Common.LayoutAwarePage
    {
        public AddUserStoryView()
        {
            this.InitializeComponent();

            vm = new AddUserStoryViewModel();
            this.DataContext = vm;

            this.Loaded += AddUserStoryView_Loaded;
        }

        void AddUserStoryView_Loaded(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            // Setting the initial state of the application
            VisualStateManager.GoToState(control, ApplicationView.Value.ToString(), false);
            if (this.layoutAwareControls == null)
            {
                layoutAwareControls = new List<Control>();
            }
            this.layoutAwareControls.Add(control);

            Window.Current.SizeChanged += Current_SizeChanged;
        }

        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            string visualState = ApplicationView.Value.ToString();

            if (this.layoutAwareControls != null)
            {
                foreach (var layoutAwareControl in this.layoutAwareControls)
                {
                    VisualStateManager.GoToState(layoutAwareControl, visualState, false);
                }
            }
        }

        private AddUserStoryViewModel vm;
        private List<Control> layoutAwareControls;

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

        private void SaveUserStory_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            // Rules - only title is required.
            if (txtTitle.Text.Length == 0)
            {
                errTitle.Visibility = Visibility.Visible;
                return;
            }

            vm.SaveUserStory(txtTitle.Text, txtDescription.Text, sliPriority.Value);

            var button = sender as Button;
            if (button.Content.Equals("Save and exit"))
            {
                this.Frame.GoBack();
            }
            else if (button.Content.Equals("Save and add another"))
            {
                txtDescription.Text = "";
                txtTitle.Text = "";
                sliPriority.Value = 500;

                // TODO: Add toast
            }
        }

        private void txtTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            errTitle.Visibility = Visibility.Collapsed;
        }

    }
}
