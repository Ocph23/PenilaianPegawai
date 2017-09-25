using App.Services;
using App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Helpers
{
    public static class Mainpage
    {
        private static string _server= "http://penilaianpegawai.gear.host/";

        public static async Task<BaseMain> GetMainPageAsync()
        {
            var x = await Task.FromResult(Xamarin.Forms.Application.Current.MainPage);
            return x as BaseMain;
        }

        public static AuthenticationToken Token { get; set; }
        public static string Server {
            get
            {
                return _server;
            }
            set
            {
                _server = "http://"+value+"/";
            }
        }
    }
}
