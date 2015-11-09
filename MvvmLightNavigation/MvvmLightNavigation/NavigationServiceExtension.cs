using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightNavigationExtension
{
    public static class NavigationServiceExtension
    {
        public static void OpenModal(this INavigationService navigationService, string key)
        {
            var extension = ServiceLocator.Current.GetInstance<INavigationServiceExtension>();

            extension.OpenModal(key);
        }

        public static void CloseModal(this INavigationService navigationService)
        {
            var extension = ServiceLocator.Current.GetInstance<INavigationServiceExtension>();

            extension.CloseModal();
        }
    }
}
