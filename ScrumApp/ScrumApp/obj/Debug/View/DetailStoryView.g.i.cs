﻿

#pragma checksum "C:\Users\selbekk\Documents\GitHub\appathon\ScrumApp\ScrumApp\View\DetailStoryView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD4CF7E8EB7CA7242C15FEB1FCC5CF2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace ScrumApp.View
{
    partial class DetailStoryView : ScrumApp.Common.LayoutAwarePage
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private ScrumApp.Common.LayoutAwarePage pageRoot; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.ListBox CommentList; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.TextBlock DescriptionBox; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.TextBlock TitleBox; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.Button backButton; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.Controls.TextBlock pageTitle; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.VisualStateGroup ApplicationViewStates; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.VisualState FullScreenLandscape; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.VisualState Filled; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.VisualState FullScreenPortrait; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private Windows.UI.Xaml.VisualState Snapped; 
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            Application.LoadComponent(this, new System.Uri("ms-appx:///View/DetailStoryView.xaml"), Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            pageRoot = (ScrumApp.Common.LayoutAwarePage)this.FindName("pageRoot");
            CommentList = (Windows.UI.Xaml.Controls.ListBox)this.FindName("CommentList");
            DescriptionBox = (Windows.UI.Xaml.Controls.TextBlock)this.FindName("DescriptionBox");
            TitleBox = (Windows.UI.Xaml.Controls.TextBlock)this.FindName("TitleBox");
            backButton = (Windows.UI.Xaml.Controls.Button)this.FindName("backButton");
            pageTitle = (Windows.UI.Xaml.Controls.TextBlock)this.FindName("pageTitle");
            ApplicationViewStates = (Windows.UI.Xaml.VisualStateGroup)this.FindName("ApplicationViewStates");
            FullScreenLandscape = (Windows.UI.Xaml.VisualState)this.FindName("FullScreenLandscape");
            Filled = (Windows.UI.Xaml.VisualState)this.FindName("Filled");
            FullScreenPortrait = (Windows.UI.Xaml.VisualState)this.FindName("FullScreenPortrait");
            Snapped = (Windows.UI.Xaml.VisualState)this.FindName("Snapped");
        }
    }
}



