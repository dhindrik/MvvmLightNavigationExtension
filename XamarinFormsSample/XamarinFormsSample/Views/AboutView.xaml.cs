using Sample.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Sample.Forms.Views
{
    public partial class AboutView : ContentPage
    {
        public AboutView()
        {
            InitializeComponent();

            BindingContext = new AboutViewModel();
        }
    }
}
