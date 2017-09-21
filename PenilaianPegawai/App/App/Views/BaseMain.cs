using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.Views
{
    public class BaseMain : TabbedPage
    {
        public AuthenticationToken Token { get; set; }

        public BaseMain(AuthenticationToken  token)
        {
            Token = token;
            Children.Add(new NavigationPage(new Views.Main.Home(token))
            {
                Title = "Home",
                Icon = Device.OnPlatform("tab_feed.png", null, null)
            });
            Children.Add(new NavigationPage(new Views.Main.PegawaiView(token))
            {
                Title = "Pegawai",
                Icon = Device.OnPlatform("tab_about.png", null, null)
            });
        }
    }
}