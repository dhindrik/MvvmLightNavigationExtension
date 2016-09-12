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
        public static INavigationServiceExtension Current { get; set; }

        public static void OpenModal(this INavigationService navigationService, string key)
        {
            Current.OpenModal(key);
        }

        public static void OpenModal(this INavigationService navigationService, string key, object parameter)
        {
            Current.OpenModal(key, parameter);
        }

        public static void CloseModal(this INavigationService navigationService)
        {
            Current.CloseModal();
        }
    }
}
