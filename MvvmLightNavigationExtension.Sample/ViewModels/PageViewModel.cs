using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightNavigationExtension.Sample.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Close
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.CloseModal();
                });
            }
        }
    }
}
