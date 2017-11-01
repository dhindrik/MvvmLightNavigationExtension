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
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension.Sample.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace MvvmLightNavigationExtension.Sample.Droid
{
    [Activity(Label = "Page3Activity")]
    public class Page3Activity : ActivityBase
    {
        public PageViewModel ViewModel { get; private set; }

        public NavigationService Nav
        {
            get
            {
                return (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Page);

            if (ViewModel == null)
            {
                ViewModel = SimpleIoc.Default.GetInstance<PageViewModel>();
            }

            var text = FindViewById<TextView>(Resource.Id.textView1);

            var parameter = Nav.GetAndRemoveParameter<string>(Intent);

            text.Text += " " + parameter;

            var button = FindViewById<Button>(Resource.Id.close);
            button.SetCommand("Click", ViewModel.Close);
        }
    }
}