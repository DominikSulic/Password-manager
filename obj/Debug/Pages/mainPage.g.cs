﻿#pragma checksum "..\..\..\Pages\mainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F7B25871DDC85C22693626E96ECCBDE94912903CA6F11E5D9938EF27EBD05EA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pasword_Manager;
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


namespace Pasword_Manager {
    
    
    /// <summary>
    /// mainPage
    /// </summary>
    public partial class mainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewEntity;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOptions;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\mainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSavedEntities;
        
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
            System.Uri resourceLocater = new System.Uri("/Pasword Manager;component/pages/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\mainPage.xaml"
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
            this.btnNewEntity = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Pages\mainPage.xaml"
            this.btnNewEntity.Click += new System.Windows.RoutedEventHandler(this.BtnNewEntity_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnOptions = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\mainPage.xaml"
            this.btnOptions.Click += new System.Windows.RoutedEventHandler(this.BtnOptions_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSavedEntities = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Pages\mainPage.xaml"
            this.btnSavedEntities.Click += new System.Windows.RoutedEventHandler(this.BtnSavedEntities_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

