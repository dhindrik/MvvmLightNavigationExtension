using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLightNavigationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Forms.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand About
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                    navigation.NavigateTo("About");
                });
            }
        } 
    }
}
