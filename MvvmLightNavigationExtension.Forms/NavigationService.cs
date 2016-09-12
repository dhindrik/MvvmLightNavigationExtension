using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmLightNavigationExtension.Forms
{
    public class NavigationService : INavigationService, INavigationServiceExtension
    {
        private INavigation _navigation;
        private Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public void Initialize(INavigation navigation)
        {
            _navigation = navigation;
            NavigationServiceExtension.Current = this;
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
            get; private set;
        }

        public void CloseModal()
        {
            _navigation.PopModalAsync();
        }

        public void GoBack()
        {
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

            CurrentPageKey = pageKey;  
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
