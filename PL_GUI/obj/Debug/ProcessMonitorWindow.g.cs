﻿#pragma checksum "..\..\ProcessMonitorWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "28D1BACEB82150BBDC00A5E301979447"
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
    /// ProcessMonitorWindow
    /// </summary>
    public partial class ProcessMonitorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\ProcessMonitorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_To_Main_Menu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ProcessMonitorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button End_Task;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ProcessMonitorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Process_List;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\ProcessMonitorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumnHeader cpu;
        
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
            System.Uri resourceLocater = new System.Uri("/PL_GUI;component/processmonitorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProcessMonitorWindow.xaml"
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
            this.Back_To_Main_Menu = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ProcessMonitorWindow.xaml"
            this.Back_To_Main_Menu.Click += new System.Windows.RoutedEventHandler(this.Back_To_Main_Menu_Left_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.End_Task = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\ProcessMonitorWindow.xaml"
            this.End_Task.Click += new System.Windows.RoutedEventHandler(this.Kill_Process);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Process_List = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            
            #line 45 "..\..\ProcessMonitorWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Sort_By_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 51 "..\..\ProcessMonitorWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Sort_By_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cpu = ((System.Windows.Controls.GridViewColumnHeader)(target));
            
            #line 57 "..\..\ProcessMonitorWindow.xaml"
            this.cpu.Click += new System.Windows.RoutedEventHandler(this.Sort_By_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 63 "..\..\ProcessMonitorWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Sort_By_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 41 "..\..\ProcessMonitorWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 41 "..\..\ProcessMonitorWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

