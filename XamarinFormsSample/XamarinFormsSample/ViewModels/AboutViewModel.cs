using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightNavigationExtension;

namespace XamarinFormsSample.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public RelayCommand ShowModal
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = SimpleIoc.Default.GetInstance<INavigationService>();
                    navigation.OpenModal("Modal");
                });
            }
        }
    }
}
