using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();
        }

        public Home(AuthenticationToken token)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.Main.HomeViewModel(Navigation,token);
        }
    }
}