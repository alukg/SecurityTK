﻿#pragma checksum "..\..\CryptoWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A240CF0AA7DA74388238783F29A95F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PL_GUI;
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


namespace PL_GUI {
    
    
    /// <summary>
    /// CryptoWindow
    /// </summary>
    public partial class CryptoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PasswordN;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encrypt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button decrypt;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Choose_File;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Choose_Folder;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainMenu;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CryptoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter;
        
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
            System.Uri resourceLocater = new System.Uri("/PL_GUI;component/cryptowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CryptoWindow.xaml"
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
            this.PasswordN = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\CryptoWindow.xaml"
            this.encrypt.Click += new System.Windows.RoutedEventHandler(this.encrypt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.decrypt = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\CryptoWindow.xaml"
            this.decrypt.Click += new System.Windows.RoutedEventHandler(this.decrypt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Choose_File = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\CryptoWindow.xaml"
            this.Choose_File.Click += new System.Windows.RoutedEventHandler(this.Choose_File_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Choose_Folder = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\CryptoWindow.xaml"
            this.Choose_Folder.Click += new System.Windows.RoutedEventHandler(this.Choose_Folder_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\CryptoWindow.xaml"
            this.MainMenu.Click += new System.Windows.RoutedEventHandler(this.MainMenu_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\CryptoWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Enter = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\CryptoWindow.xaml"
            this.Enter.Click += new System.Windows.RoutedEventHandler(this.Enter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

