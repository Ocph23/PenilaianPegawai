using App.Helpers;
using App.Models;
using App.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels.Main
{
   public  class HomeViewModel:BaseViewModel
    {
        private pegawai _profile;
        private AuthenticationToken token;

        public HomeViewModel(INavigation nav)
        {
            this.Navigation = nav;
           
        }

        public HomeViewModel(INavigation navigation, AuthenticationToken token)
        {
            Navigation = navigation;
            this.token = token;
            this.Load();
        }

        private async void Load()
        {

            using (var service = new RestService())
            {
                try
                {
                    await service.SetTokenAsync(token);
                    var response = await service.GetAsync("api/pegawai/getpenilaiprofile");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        this.Profile = JsonConvert.DeserializeObject<pegawai>(content);

                    }
                    else
                    {
                        throw new System.Exception(response.StatusCode.ToString());
                    }
                }
                catch (Exception ex)
                {

                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Error",
                        Message = ex.Message,
                        Cancel = "OK"
                    }, "message");
                }
            }
        }

        public INavigation Navigation { get; }
        public pegawai Profile {
            get { return _profile; }
            set
            {
                SetProperty(ref _profile, value);
            }
        }
    }
}
