﻿using System;
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
using SharedResources.Controller;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ScrumApp.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DetailStoryView : ScrumApp.Common.LayoutAwarePage
    {
        private DetailStoryViewModel detailStoryViewModel;
        public DetailStoryView()
        {
            this.InitializeComponent();
            detailStoryViewModel = new DetailStoryViewModel();
            DataContext = detailStoryViewModel;
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
            var story = navigationParameter as Story;
            if (story == null)
            {
                // TODO: Error handling for missing project
            }
            else
            {
                detailStoryViewModel.UserStory = story;
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

        private void AssigneeField_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailUserView), detailStoryViewModel.UserStory.Assignee);
        }

        private void CommentAuthorField_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            string username = (sender as TextBlock).Tag.ToString();
            UserController uc = new UserController();
            User author = uc.findUser(username);
            
            this.Frame.Navigate(typeof(DetailUserView), author);
        }
    }
}
