using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightNavigationExtension.Sample.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        public RelayCommand Close
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                    navigation.CloseModal();
                });
            }
        }
    }
}
