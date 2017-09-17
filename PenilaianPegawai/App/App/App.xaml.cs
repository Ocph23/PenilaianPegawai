using App.Services;
using App.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Helpers.MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });
            SetMainPage();
        }

        public static void SetMainPage()
        {

            var login = new Views.LoginView();

            Current.MainPage = login;

         
        }


        public void ChangeScreen(Page page)
        {
            Current.MainPage = page;

        }
    }
}
