using Xamarin.Forms;

namespace App3.ViewModels
{
    internal class MainViewModel
    {
        private INavigation navigation;

        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}