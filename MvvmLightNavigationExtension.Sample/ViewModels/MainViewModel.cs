
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightNavigationExtension;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightNavigationExtension.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Goto
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.OpenModal("Page2");
                });
            }
        }

        public RelayCommand GotoWithParameter
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.OpenModal("Page3", "hej");
                });
            }
        }
    }
}
