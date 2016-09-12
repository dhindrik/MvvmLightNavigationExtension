// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmLightNavigationExtension.Sample.iOS
{
    [Register ("Page3Controller")]
    partial class Page3Controller
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Close { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Text { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Close != null) {
                Close.Dispose ();
                Close = null;
            }

            if (Text != null) {
                Text.Dispose ();
                Text = null;
            }
        }
    }
}