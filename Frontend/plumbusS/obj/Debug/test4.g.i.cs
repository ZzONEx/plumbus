﻿#pragma checksum "..\..\Test4.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3266144CEB8B2FFD7746649C8E177EA90BA3F268A13F4E66CF8950205B6E28BF"
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


namespace plumbusS {
    
    
    /// <summary>
    /// Test4
    /// </summary>
    public partial class Test4 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 79 "..\..\Test4.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button popygai;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Test4.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ingridient;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Test4.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button planet;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Test4.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button money;
        
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
            System.Uri resourceLocater = new System.Uri("/plumbusS;component/test4.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Test4.xaml"
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
            this.popygai = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Test4.xaml"
            this.popygai.Click += new System.Windows.RoutedEventHandler(this.Popygai_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ingridient = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\Test4.xaml"
            this.ingridient.Click += new System.Windows.RoutedEventHandler(this.Ingridient_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.planet = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\Test4.xaml"
            this.planet.Click += new System.Windows.RoutedEventHandler(this.Planet_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.money = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\Test4.xaml"
            this.money.Click += new System.Windows.RoutedEventHandler(this.Money_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 83 "..\..\Test4.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ToMainWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

