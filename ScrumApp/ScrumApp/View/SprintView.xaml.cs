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
using SharedResources.Utilities;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SprintView : ScrumApp.Common.LayoutAwarePage
    {
        private SprintViewModel sprintViewModel;

        public SprintView()
        {
            this.InitializeComponent();
            sprintViewModel = new SprintViewModel();
            DataContext = sprintViewModel;
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
            var sprint = navigationParameter as Sprint;
            if (sprint == null)
            {
                // TODO: Error handling for missing project
            }
            else
            {
                sprintViewModel.CurrentSprint = sprint;

                foreach (Story story in sprint.Stories)
                {
                    switch (story.State)
                    {
                        case StoryStates.Closed: sprintViewModel.Closed.Add(story);
                            break;
                        case StoryStates.InAnalysis: sprintViewModel.InAnalysis.Add(story);
                            break;
                        case StoryStates.InProgress: sprintViewModel.InProgress.Add(story);
                            break;
                        case StoryStates.Open: sprintViewModel.Open.Add(story);
                            break;
                        case StoryStates.Testing: sprintViewModel.Testing.Add(story);
                            break;
                        case StoryStates.Unassigned:
                            break;
                    }
                }
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

    }
}
