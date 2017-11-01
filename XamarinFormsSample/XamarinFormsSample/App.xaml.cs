using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinFormsSample
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var navigationPage = new NavigationPage();

            var navigationService = new NavigationService();
            navigationService.Initialize(navigationPage);

            navigationService.Configure("Main", typeof(MainView));
            navigationService.Configure("About", typeof(AboutView));
            navigationService.Configure("Modal", typeof(ModalView));


            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());

            navigationPage.PushAsync(new MainView());

            MainPage = navigationPage;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
