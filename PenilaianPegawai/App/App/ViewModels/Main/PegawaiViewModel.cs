using App.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App.Services;

namespace App.ViewModels.Main
{
    public class PegawaiViewModel:BaseViewModel
    {
        private INavigation navigation;
        private AuthenticationToken token;

        public Command LoadItemsCommand { get; private set; }
        public ObservableCollection<Models.pegawai> Pegawais { get;  set; }

        public PegawaiViewModel(INavigation navigation, AuthenticationToken token)
        {
            this.navigation = navigation;
            this.token = token;
            Pegawais = new ObservableCollection<Models.pegawai>();
            LoadItemsCommand = new Command((x) => ExecuteLoadItemsCommand(x));
            ExecuteLoadItemsCommand(null);
        }

        private async void ExecuteLoadItemsCommand(object x)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                Pegawais.Clear();
                var pegawais = await PegawaiDataStore.GetItemsAsync(true);
                foreach (var item in pegawais)
                {
                    Pegawais.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal async Task ShowDetailAsync(int v)
        {
            var pegawai = await PegawaiDataStore.GetItemAsync(v.ToString());
            if(pegawai!=null)
            {
                await navigation.PushAsync(new Views.Details.PegawaiDetailView(pegawai));
            }else
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Data Tidak Ditemukan",
                    Cancel = "OK"
                }, "message");
            }
        }
    }
}
