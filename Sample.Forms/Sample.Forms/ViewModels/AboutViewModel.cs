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

namespace Sample.Forms.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public RelayCommand ShowModal
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                    navigation.OpenModal("Modal");
                });
            }
        }
    }
}
