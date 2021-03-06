﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScrumApp.View;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScrumApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void testButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailStoryView));
        }

        private void SprintViewTestButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SprintView));
        }

        private void SprintViewTestButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddUserStoryView));
        }

        private void SprintViewTestButton_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginView));
        }

        private void SprintViewTestButton_Click_4(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddProjectView));
        }

        private void AddUserTestButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddUserView));
        }

        private void DetailUserViewButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailUserView));
        }

        private void ShowAllProjectsView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllProjectsView));
        }

        private void AddSprintViewButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSprintView));
        }

    }
}
