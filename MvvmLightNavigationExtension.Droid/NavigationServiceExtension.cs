using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightNavigationExtension.Droid
{
    public class NavigationServiceExtension : NavigationService, INavigationServiceExtension
    {
        private Dictionary<string, Type> _pageKeys = new Dictionary<string, Type>();

        public void CloseModal()
        {
			ActivityBase.CurrentActivity.Finish ();
        }

        public void OpenModal(string key)
        {
            var activityType = _pageKeys[key];

            var intent = new Intent(Application.Context, activityType);
            intent.SetFlags(ActivityFlags.NoHistory);
			intent.SetFlags (ActivityFlags.NewTask);

            Application.Context.StartActivity(intent);
        }

        public new void Configure(string key, Type activityType)
        {
            base.Configure(key, activityType);

            _pageKeys.Add(key, activityType);
        }
    }
}