// Updated by XamlIntelliSenseFileGenerator 05.10.2023 16:18:03
#pragma checksum "..\..\..\Windows\Register.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1429BB8A63036890A8019073B88B875BDB48BDFEDD0CA9ED3B2E2C13CA38E96A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Pac_Man.Windows;
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


namespace Pac_Man.Windows
{


    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 115 "..\..\..\Windows\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CleanInfo;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Pac_Man;component/windows/register.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Windows\Register.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.RegisterNow = ((System.Windows.Controls.Button)(target));

#line 68 "..\..\..\Windows\Register.xaml"
                    this.RegisterNow.Click += new System.Windows.RoutedEventHandler(this.RegisterNow_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.NameInput = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 4:
                    this.Passowrd = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 5:
                    this.CleanInfo = ((System.Windows.Controls.Grid)(target));
                    return;
                case 6:
                    this.PasswordClear = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.NameClear = ((System.Windows.Controls.TextBlock)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button ButtonYourAccount;
        internal System.Windows.Controls.Button ButtonSettings;
        internal System.Windows.Controls.Button ButtonRegister;
    }
}

