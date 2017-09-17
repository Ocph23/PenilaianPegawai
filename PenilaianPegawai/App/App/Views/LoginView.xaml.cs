using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static App.Services.RestService;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        private AuthenticationToken token;

        public LoginView()
        {
            InitializeComponent();
            this.VM = new ViewModels.LoginViewModel(this.Navigation);
            this.BindingContext = VM;
        }

       

        public LoginViewModel VM { get; }
     

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var entry = sender as Entry;
            if(!string.IsNullOrEmpty(entry.Text))
            {
                VM.Password = entry.Text;
            }
          
        }
    }
}