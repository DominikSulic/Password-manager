﻿#pragma checksum "..\..\..\Pages\savedEntitiesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C89C3AF8C01C783DE7DCE31AD08A3B2E5B3863AB40C46FCEB0F2B9C4ABD2BB5D"
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
    /// savedEntitiesPage
    /// </summary>
    public partial class savedEntitiesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\savedEntitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbEntities;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\savedEntitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbPreview;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\savedEntitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\savedEntitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlter;
        
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
            System.Uri resourceLocater = new System.Uri("/Pasword Manager;component/pages/savedentitiespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\savedEntitiesPage.xaml"
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
            this.lbEntities = ((System.Windows.Controls.ListBox)(target));
            
            #line 13 "..\..\..\Pages\savedEntitiesPage.xaml"
            this.lbEntities.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LbEntities_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbPreview = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Pages\savedEntitiesPage.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAlter = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Pages\savedEntitiesPage.xaml"
            this.btnAlter.Click += new System.Windows.RoutedEventHandler(this.BtnAlter_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 41 "..\..\..\Pages\savedEntitiesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

