using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmLight.XamarinForms
{
    public class NavigationService : INavigationService, INavigationServiceExtension
    {
        internal static NavigationPage NavigationPage { get; private set; }

        private INavigation _navigation;
        private Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        private Stack<string> _navigationStack = new Stack<string>();
        public void Initialize(NavigationPage navigationPage)
        {
            _navigation = navigationPage.Navigation;
            NavigationServiceExtension.Current = this;

            NavigationPage = navigationPage;
        }

        public void Configure(string key, Type type)
        {
            lock(_pages)
            {
                if(_pages.ContainsKey(key))
                {
                    _pages[key] = type;
                }
                else
                {
                    _pages.Add(key, type);
                }

            }
        }

        public string CurrentPageKey
        {
            get { return _navigationStack.Peek(); }
        }

        public void CloseModal()
        {
            _navigation.PopModalAsync();
        }

        public void GoBack()
        {
            _navigationStack.Pop();
            _navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            var type = _pages[pageKey];

            Page page = null;

            if (parameter != null)
            {
                page = Activator.CreateInstance(type, parameter) as Page;
            }
            else
            {
                page = Activator.CreateInstance(type) as Page;
            }

            _navigation.PushAsync(page);

            _navigationStack.Push(pageKey); 
        }

        public void OpenModal(string key)
        {
            var type = _pages[key];

            Page page = Activator.CreateInstance(type) as Page;
            
            _navigation.PushModalAsync(page);
        }

        public void OpenModal(string key, object parameter)
        {
            var type = _pages[key];

            Page page = null;

            if (parameter != null)
            {
                page = Activator.CreateInstance(type, parameter) as Page;
            }
            else
            {
                page = Activator.CreateInstance(type) as Page;
            }

            _navigation.PushModalAsync(page);
        }
    }
}
