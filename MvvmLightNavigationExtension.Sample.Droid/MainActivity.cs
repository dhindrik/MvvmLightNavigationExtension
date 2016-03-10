using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;
using MvvmLightNavigationExtension.Sample.ViewModels;
using GalaSoft.MvvmLight.Helpers;

namespace MvvmLightNavigationExtension.Sample.Droid
{
    [Activity(Label = "MvvmLightNavigationExtension.Sample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        public MainViewModel ViewModel { get; private set; }

        public Button _button;


        private bool _isInitialized = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!_isInitialized)
            {
                var nav = new MvvmLightNavigationExtension.Droid.NavigationServiceExtension();
                nav.Initialize();
                nav.Configure("Page1", typeof(MainActivity));
                nav.Configure("Page2", typeof(PageActivity));

                var builder = new ContainerBuilder();
                builder.RegisterInstance<INavigationService>(nav);
                builder.RegisterInstance<INavigationServiceExtension>(nav);

                var container = builder.Build();

                ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

                _isInitialized = true;

                ViewModel = new MainViewModel();
            }



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            // Get our button from the layout resource,
            // and attach an event to it
            _button = FindViewById<Button>(Resource.Id.MyButton);
            _button.SetCommand("Click", ViewModel.Goto);

            _button.Click += _button_Click;
        }

        private void _button_Click(object sender, EventArgs e)
        {
           
        }
    }
}

