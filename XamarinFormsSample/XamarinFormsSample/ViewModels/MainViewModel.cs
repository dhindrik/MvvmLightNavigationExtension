
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand About
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var navigation = SimpleIoc.Default.GetInstance<INavigationService >();
                    navigation.NavigateTo("About");
                });
            }
        }

        public RelayCommand Dialog
        {
            get
            {
                return new RelayCommand(async() =>
                {
                    var dialog = SimpleIoc.Default.GetInstance<IDialogService>();
                    await dialog.ShowMessage("Hi!", "Whats up?");
                });
            }
        }
    }
}
