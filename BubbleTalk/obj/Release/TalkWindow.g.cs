﻿#pragma checksum "..\..\TalkWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BCCCC2D31D298532642DC3B30D34674B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using SideTalk;
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


namespace SideTalk {
    
    
    /// <summary>
    /// TalkWindow
    /// </summary>
    public partial class TalkWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image settings;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid myGrid;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clb;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputText;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer sv;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel textfield;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UploadBtn;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\TalkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement voice;
        
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
            System.Uri resourceLocater = new System.Uri("/SideTalk;component/talkwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TalkWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 6 "..\..\TalkWindow.xaml"
            ((SideTalk.TalkWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 67 "..\..\TalkWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Grid_MouseMove);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 86 "..\..\TalkWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 87 "..\..\TalkWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp_1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 89 "..\..\TalkWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.settings = ((System.Windows.Controls.Image)(target));
            
            #line 92 "..\..\TalkWindow.xaml"
            this.settings.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.settings_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 92 "..\..\TalkWindow.xaml"
            this.settings.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.settings_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.myGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.clb = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.InputText = ((System.Windows.Controls.TextBox)(target));
            
            #line 105 "..\..\TalkWindow.xaml"
            this.InputText.GotFocus += new System.Windows.RoutedEventHandler(this.InputText_GotFocus);
            
            #line default
            #line hidden
            
            #line 105 "..\..\TalkWindow.xaml"
            this.InputText.KeyDown += new System.Windows.Input.KeyEventHandler(this.InputText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sv = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 11:
            this.textfield = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.UploadBtn = ((System.Windows.Controls.Image)(target));
            
            #line 111 "..\..\TalkWindow.xaml"
            this.UploadBtn.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.UploadBtn_MouseUp);
            
            #line default
            #line hidden
            
            #line 111 "..\..\TalkWindow.xaml"
            this.UploadBtn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UploadBtn_MouseDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.voice = ((System.Windows.Controls.MediaElement)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

