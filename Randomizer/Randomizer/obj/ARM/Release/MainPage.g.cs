﻿#pragma checksum "E:\GitHub\CSSARandomizer\Randomizer\Randomizer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C4777ABF35B3A85DA58E033A581B7AF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Randomizer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.layout = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click_2;
                    #line default
                }
                break;
            case 4:
                {
                    this.texblk = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 30 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.texblk).SelectionChanged += this.TextBlock_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.texCol = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.texRow = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element8 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 37 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element8).SelectionChanged += this.TextBlock_SelectionChanged_1;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element9 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 39 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element9).SelectionChanged += this.TextBlock_SelectionChanged_1;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

