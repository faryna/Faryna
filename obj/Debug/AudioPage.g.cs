﻿#pragma checksum "..\..\AudioPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0473CC1BDBB0A2B94971F4C54698C5B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace VK_API {
    
    
    /// <summary>
    /// AudioPage
    /// </summary>
    public partial class AudioPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid audioGrid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox MusicBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPrev;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPlayPause;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonNext;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SliderVolume;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AudioPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox _lisFriendMusic;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Faryna;component/audiopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AudioPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.audioGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.MusicBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 10 "..\..\AudioPage.xaml"
            this.MusicBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonPrev = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AudioPage.xaml"
            this.buttonPrev.Click += new System.Windows.RoutedEventHandler(this.buttonPrev_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonPlayPause = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AudioPage.xaml"
            this.buttonPlayPause.Click += new System.Windows.RoutedEventHandler(this.buttonPlayPause_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonNext = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\AudioPage.xaml"
            this.buttonNext.Click += new System.Windows.RoutedEventHandler(this.buttonNext_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.slider1 = ((System.Windows.Controls.Slider)(target));
            
            #line 14 "..\..\AudioPage.xaml"
            this.slider1.IsMouseCaptureWithinChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.slider1_IsMouseCaptureWithinChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SliderVolume = ((System.Windows.Controls.Slider)(target));
            
            #line 15 "..\..\AudioPage.xaml"
            this.SliderVolume.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SliderVolume_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this._lisFriendMusic = ((System.Windows.Controls.ListBox)(target));
            
            #line 16 "..\..\AudioPage.xaml"
            this._lisFriendMusic.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this._lisFriendMusic_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 19 "..\..\AudioPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 23 "..\..\AudioPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
