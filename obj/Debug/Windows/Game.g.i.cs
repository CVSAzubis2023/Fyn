﻿#pragma checksum "..\..\..\Windows\Game.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85218FE3008F70B8337BC33241FA59072FE7FE35864E540A783F609E3FEF4DF9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Pac_Man;
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


namespace Pac_Man {
    
    
    /// <summary>
    /// Game
    /// </summary>
    public partial class Game : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 130 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Waende;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSettings;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 255 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPlay;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBack;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle PlayerPacMan;
        
        #line default
        #line hidden
        
        
        #line 308 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GhostRed;
        
        #line default
        #line hidden
        
        
        #line 325 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GhostBlue;
        
        #line default
        #line hidden
        
        
        #line 334 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GhostOrange;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\..\Windows\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GhostPurple;
        
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
            System.Uri resourceLocater = new System.Uri("/Pac_Man;component/windows/game.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Game.xaml"
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
            
            #line 15 "..\..\..\Windows\Game.xaml"
            ((Pac_Man.Game)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Game_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Waende = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 209 "..\..\..\Windows\Game.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonSettings = ((System.Windows.Controls.Button)(target));
            
            #line 225 "..\..\..\Windows\Game.xaml"
            this.ButtonSettings.Click += new System.Windows.RoutedEventHandler(this.ButtonSettings_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 239 "..\..\..\Windows\Game.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonPlay = ((System.Windows.Controls.Button)(target));
            
            #line 256 "..\..\..\Windows\Game.xaml"
            this.ButtonPlay.Click += new System.Windows.RoutedEventHandler(this.ButtonPlay_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonBack = ((System.Windows.Controls.Button)(target));
            
            #line 285 "..\..\..\Windows\Game.xaml"
            this.ButtonBack.Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PlayerPacMan = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 9:
            this.GhostRed = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 10:
            this.GhostBlue = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 11:
            this.GhostOrange = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 12:
            this.GhostPurple = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

