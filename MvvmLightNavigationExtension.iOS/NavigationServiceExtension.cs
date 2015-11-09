using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace MvvmLightNavigationExtension.iOS
{
    public class NavigationServiceExtension : NavigationService, INavigationServiceExtension
    {
        private Dictionary<string, string> _pageKeys = new Dictionary<string, string>();

        public void OpenModal(string key)
        {
            var navigationController = UIApplication.SharedApplication.Windows[0].RootViewController;
        
            var navigationService = (NavigationServiceExtension)ServiceLocator.Current.GetInstance<INavigationService>();
          
            var viewController = navigationController.Storyboard.InstantiateViewController(_pageKeys[key]);

            navigationController.PresentModalViewController(viewController, true);
        }

        public void CloseModal()
        {
            var navigationController = UIApplication.SharedApplication.Windows[0].RootViewController;
            navigationController.DismissModalViewController(true);
        }

        public new void Configure(string key, string storyboardId)
        {
            base.Configure(key, storyboardId);

            _pageKeys.Add(key, storyboardId);
        }

        
    }
}
