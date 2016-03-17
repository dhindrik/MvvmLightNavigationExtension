using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLightNavigationExtension;
using MvvmLightNavigationExtension.Forms;
using Sample.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Sample.Forms
{
    public class App : Application
    {
        public App()
        {
            var navigationPage = new NavigationPage();

            var navigationService = new NavigationService();
            navigationService.Initialize(navigationPage.Navigation);

            navigationService.Configure("Main", typeof(MainView));
            navigationService.Configure("About", typeof(AboutView));
            navigationService.Configure("Modal", typeof(ModalView));

            var builder = new ContainerBuilder();
            builder.RegisterInstance<INavigationService>(navigationService);

            var container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            navigationPage.PushAsync(new MainView());

            MainPage = navigationPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
