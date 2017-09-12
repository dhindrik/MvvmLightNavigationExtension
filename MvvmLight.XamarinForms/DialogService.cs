using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace MvvmLight.XamarinForms
{
    public class DialogService : IDialogService
    {
        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            await NavigationService.Page.DisplayAlert(title, error.Message, buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback(); 
            }
        }

        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            await NavigationService.Page.DisplayAlert(title, message, buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowMessage(string message, string title)
        {
            await NavigationService.Page.DisplayAlert(title, message, "OK");
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            await NavigationService.Page.DisplayAlert(title, message, buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            var result = await NavigationService.Page.DisplayAlert(title, message, buttonConfirmText, buttonCancelText);

            if (afterHideCallback != null)
            {
                afterHideCallback(result);
            }

            return result;
        }

        public async Task ShowMessageBox(string message, string title)
        {
            await NavigationService.Page.DisplayAlert(title, message, "OK");
        }
    }
}
