using App.Helpers;
using App.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using App.Services;

namespace App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private Command _loginCommand;
        private AuthenticationToken token;

        public Command LoginCommand { get { return _loginCommand; } set { SetProperty(ref _loginCommand, value); } }
        public INavigation Navigation { get; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginCommand = new Command((x) => LoginAction(x), x => LoginValidate(x));
        }

        private bool LoginValidate(object arg)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            return false;
        }

        private async void LoginAction(object x)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                using (var res = new Services.RestService())
                {
                    this.Email = "Ajn26@gmail.com";
                    this.Password = "Penilai@123";
                    token = await res.GenerateTokenAsync(this.Email, Password);
                    if (token != null)
                    {
                        var main = new BaseMain(token);
                        Helpers.Mainpage.Token = token;
                        ((App)App.Current).ChangeScreen(main);
                    }
                    else
                    {
                        MessagingCenter.Send(new MessagingCenterAlert
                        {
                            Title = "Error",
                            Message = "Gagal Login",
                            Cancel = "OK"
                        }, "message");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }

            //procces here

        }

        public string Email
        {
            get { return _email; }
            set
            {
                LoginCommand = new Command((x) => LoginAction(x), LoginValidate);
                SetProperty(ref _email, value);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
               LoginCommand = new Command((x) => LoginAction(x), LoginValidate);
                SetProperty(ref _password, value);
            }
        }
    }
}
