﻿#pragma checksum "..\..\Input.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "485D49460C118A72D29F4B252C7B98236CB6F6C4CAF17905D6026A5A204C8886"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using plumbusS;


namespace plumbusS {
    
    
    /// <summary>
    /// INPUT
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 167 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginent;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordB;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enter;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonbekreg;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roles_Cbx;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\Input.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
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
            System.Uri resourceLocater = new System.Uri("/plumbusS;component/input.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Input.xaml"
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
            this.loginent = ((System.Windows.Controls.TextBox)(target));
            
            #line 167 "..\..\Input.xaml"
            this.loginent.KeyDown += new System.Windows.Input.KeyEventHandler(this.EnterKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.passwordB = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 168 "..\..\Input.xaml"
            this.passwordB.KeyDown += new System.Windows.Input.KeyEventHandler(this.EnterKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.enter = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\Input.xaml"
            this.enter.Click += new System.Windows.RoutedEventHandler(this.LogIn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonbekreg = ((System.Windows.Controls.Button)(target));
            
            #line 170 "..\..\Input.xaml"
            this.buttonbekreg.Click += new System.Windows.RoutedEventHandler(this.BackToRegistr_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.roles_Cbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\Input.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

