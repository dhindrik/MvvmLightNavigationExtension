using Foundation;
using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension.Sample.ViewModels;
using System;
using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace MvvmLightNavigationExtension.Sample.iOS
{
    public partial class Page3Controller : ControllerBase
    {
        public Page3Controller (IntPtr handle) : base (handle)
        {

        }

        public PageViewModel ViewModel { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = new PageViewModel();

            Text.Text = "Parameter: " + NavigationParameter.ToString();

            Close.SetCommand("TouchUpInside", ViewModel.Close);
        }
    }
}