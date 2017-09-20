using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using App.Helpers;
using System.Net.Http;

[assembly: Dependency(typeof(App.Services.DetailPenilaianDataStore))]
namespace App.Services
{
    public class DetailPenilaianDataStore : IDataStore<Models.detailpenilaian>
    {
        public Task<bool> AddItemAsync(detailpenilaian item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(detailpenilaian item)
        {
            throw new NotImplementedException();
        }

        public Task<detailpenilaian> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<detailpenilaian>> GetItemsAsync(bool forceRefresh = false)
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

        public async Task<bool> UpdateItemAsync(detailpenilaian item)
        {
            var isUpdated = false;
            using (var service = new RestService())
            {
                try
                {
                    await service.CekTokenAsync();
                    var data = JsonConvert.SerializeObject(item, Formatting.Indented);
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await service.PostAsync("api/penilaian/put",content);
                    if (response.IsSuccessStatusCode)
                    {
                        var resultContent = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<detailpenilaian>(resultContent);
                        if(response!=null)
                        {

                        }else
                        {
                            MessagingCenter.Send(new MessagingCenterAlert
                            {
                                Title = "Error",
                                Message = "Data gagal diubah",
                                Cancel = "OK"
                            }, "message");
                        }
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
            return isUpdated;
        }
    }
}
