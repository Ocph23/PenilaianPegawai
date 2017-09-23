using App.Helpers;
using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(App.Services.PenilaianDataStore))]

namespace App.Services
{
    public class PenilaianDataStore : IDataStore<penilaian>
    {
        public Task<bool> AddItemAsync(penilaian item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(penilaian item)
        {
            throw new NotImplementedException();
        }

        public async Task<penilaian> GetItemAsync(string id)
        {
            penilaian Penilaian = null;
            using (var service = new RestService())
            {
                try
                {
                    await service.CekTokenAsync();
                    var response = await service.GetAsync("api/penilaian/get?id="+id);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Penilaian= JsonConvert.DeserializeObject<penilaian>(content);
                      
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
            return Penilaian;

        }

        public Task<IEnumerable<penilaian>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> PullLatestAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SyncAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(penilaian item)
        {
            throw new NotImplementedException();
        }
    }
}
