using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmLightNavigationExtension.Sample.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightNavigationExtension.Sample.Droid
{
    [Activity(Label = "PageActivity")]
    public class PageActivity : ActivityBase
    {
        public PageViewModel ViewModel { get; private set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Page);

            if(ViewModel == null)
            {
                ViewModel = new PageViewModel();
            }

            var button = FindViewById<Button>(Resource.Id.close);
            button.SetCommand("Click", ViewModel.Close);
        }
    }
}