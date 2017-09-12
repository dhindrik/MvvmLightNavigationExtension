using Foundation;
using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension.Sample.ViewModels;
using System;
using System.CodeDom.Compiler;
using UIKit;
using GalaSoft.MvvmLight.Helpers;

namespace MvvmLightNavigationExtension.Sample.iOS
{
	partial class PageController : ControllerBase
	{
		public PageController (IntPtr handle) : base (handle)
		{
		}


        public PageViewModel ViewModel { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = SimpleIoc.Default.GetInstance<PageViewModel>();

            Close.SetCommand("TouchUpInside", ViewModel.Close);
        }
    }
}
