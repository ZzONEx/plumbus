﻿#pragma checksum "..\..\teacher.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4C9D6657E2DA15F7C519B921B190507118235E62D79CDA46F0E2BC6DE5C75012"
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
    /// teacher
    /// </summary>
    public partial class teacher : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 122 "..\..\teacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idychenik;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\teacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox score;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\teacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DZ;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\teacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button otpravit;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\teacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Назад;
        
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
            System.Uri resourceLocater = new System.Uri("/plumbusS;component/teacher.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\teacher.xaml"
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
            this.idychenik = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\teacher.xaml"
            this.idychenik.KeyDown += new System.Windows.Input.KeyEventHandler(this.Enter_Key_Down);
            
            #line default
            #line hidden
            return;
            case 2:
            this.score = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\teacher.xaml"
            this.score.KeyDown += new System.Windows.Input.KeyEventHandler(this.Enter_Key_Down);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DZ = ((System.Windows.Controls.TextBox)(target));
            
            #line 124 "..\..\teacher.xaml"
            this.DZ.KeyDown += new System.Windows.Input.KeyEventHandler(this.Enter_Key_Down);
            
            #line default
            #line hidden
            return;
            case 4:
            this.otpravit = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\teacher.xaml"
            this.otpravit.Click += new System.Windows.RoutedEventHandler(this.otpravit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Назад = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\teacher.xaml"
            this.Назад.Click += new System.Windows.RoutedEventHandler(this.Назад_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
