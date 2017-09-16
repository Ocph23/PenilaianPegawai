using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App3.ViewModels
{
   public class LoginViewModel:BaseViewModel
    {
        private string _email;
        private string _password;
        public ICommand LoginCommand { get; set; }
        public INavigation Navigation { get; }

        public LoginViewModel(INavigation navigation)
        {
            LoginCommand = new Command(async (x) => await LoginAction(x), LoginValidate);
            this.Navigation = navigation;
        }

        private bool LoginValidate(object arg)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            return false;
        }

        private async Task LoginAction(object x)
        {
            bool IsLogin = false;
            //procces here
            if(IsLogin)
            {
              await  this.Navigation.PushModalAsync(new Views.MainView());
            }else
            {
                MessagingCenter.Send(this, "Login Gagal");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                LoginCommand = new Command(async (x) => await LoginAction(x), LoginValidate);
                SetProperty(ref _email, value);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                LoginCommand = new Command(async (x) => await LoginAction(x), LoginValidate);
                SetProperty(ref _password, value);
            }
        }
    }
}
