using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyNavigationHelper.Forms;
using Xamarin.Forms;

namespace MvvmLight.XamarinForms
{
    public class NavigationService : INavigationService, INavigationServiceExtension
    {
        internal static Page Page { get { return _app.MainPage; } }

        private static Application _app;

        private FormsNavigationHelper _navigation;

        private Stack<string> _navigationStack = new Stack<string>();
        public void Initialize(Application app)
        {
            _app = app;
            _navigation = new FormsNavigationHelper(app);

            NavigationServiceExtension.Current = this;

           
        }

        public void Configure(string key, Type type)
        {
            _navigation.RegisterView(key, type);
        }

        public string CurrentPageKey
        {
            get { return _navigationStack.Peek(); }
        }

        public void CloseModal()
        {
            _navigation.CloseModalAsync();
        }

        public void GoBack()
        {
            _navigationStack.Pop();
            _navigation.BackAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            _navigation.NavigateToAsync(pageKey, parameter);

            _navigationStack.Push(pageKey);
        }

        public void OpenModal(string key)
        {
            OpenModal(key, null);
        }

        public void OpenModal(string key, object parameter)
        {
            _navigation.OpenModalAsync(key, parameter);
        }
    }
}
