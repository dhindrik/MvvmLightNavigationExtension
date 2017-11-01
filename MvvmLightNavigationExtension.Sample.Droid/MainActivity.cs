using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension.Sample.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;

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
                nav.Configure("Page3", typeof(Page3Activity));

                SimpleIoc.Default.Register<INavigationService>(() => nav);
                SimpleIoc.Default.Register<INavigationServiceExtension>(() => nav);

                SimpleIoc.Default.Register<MainViewModel>();
                SimpleIoc.Default.Register<PageViewModel>();

                _isInitialized = true;

                ViewModel = SimpleIoc.Default.GetInstance<MainViewModel>();
            }



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            // Get our button from the layout resource,
            // and attach an event to it
            _button = FindViewById<Button>(Resource.Id.MyButton);
            _button.SetCommand("Click", ViewModel.Goto);

            _button = FindViewById<Button>(Resource.Id.MyButton2);
            _button.SetCommand("Click", ViewModel.GotoWithParameter);

            _button.Click += _button_Click;
        }

        private void _button_Click(object sender, EventArgs e)
        {
           
        }
    }
}

