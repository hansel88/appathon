﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScrumApp.Common;
using ScrumApp.Controls;
using SharedResources.Controller;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace ScrumApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Do not repeat app initialization when already running, just ensure that
            // the window is active
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                
            }

            StorageController.InitHandlers();
            StorageController.LoadData();

            // Register settings pane
            SettingsPane.GetForCurrentView().CommandsRequested += App_CommandRequested;

            // Create a Frame to act navigation context and navigate to the first page
            var rootFrame = new Frame();
            if (!rootFrame.Navigate(typeof(MainPage)))
            {
                throw new Exception("Failed to create initial page");
            }

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            StorageController.SaveData();

            // Last statement
            deferral.Complete();
        }

        void App_CommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs e)
        { 
            // Add an about command
            var about = new SettingsCommand("about", "About", (handler) =>
                {
                    var settings = new SettingsFlyout();
                    settings.ShowFlyout(new AboutUserControl());
                });
            var preferences = new SettingsCommand("preferences", "Preferences", (handler) =>
                {
                    var settings = new SettingsFlyout();
                    settings.ShowFlyout(new PreferencesUserControl());
                });
            var privacyPolicy = new SettingsCommand("privacyPolicy", "Privacy Policy", (handler) =>
                {
                    var settings = new SettingsFlyout();
                    settings.ShowFlyout(new PrivacyPolicyUserControl());
                });

            e.Request.ApplicationCommands.Add(about);
            e.Request.ApplicationCommands.Add(preferences);
            e.Request.ApplicationCommands.Add(privacyPolicy);
        }
    }
}
