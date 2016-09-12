using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightNavigationExtension;

namespace MvvmLightNavigationExtension.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand Goto
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                    navigation.OpenModal("Page2");
                });
            }
        }

        public RelayCommand GotoWithParameter
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                    navigation.OpenModal("Page3", "hej");
                });
            }
        }
    }
}
