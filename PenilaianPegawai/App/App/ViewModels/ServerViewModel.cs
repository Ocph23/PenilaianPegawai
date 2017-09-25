using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class ServerViewModel : BaseViewModel
    {
        private static string _server;
        private INavigation navigation;

        public ServerViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public static string Server
        {
            get
            {
                return Helpers.Mainpage.Server;
            }
            set
            {
                Helpers.Mainpage.Server = "http://" + value + "/";

            }
        }



    }
}