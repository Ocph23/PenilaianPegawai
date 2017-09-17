using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(App.Services.UserDataStore))]

namespace App.Services
{
    public class UserDataStore : IDataStore<pegawai>
    {
        private List<pegawai> list;

        public Task<bool> AddItemAsync(pegawai item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(pegawai item)
        {
            throw new NotImplementedException();
        }

        public Task<pegawai> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<pegawai>> GetItemsAsync(bool forceRefresh = false)
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

        public Task<bool> UpdateItemAsync(pegawai item)
        {
            throw new NotImplementedException();
        }
    }
}
