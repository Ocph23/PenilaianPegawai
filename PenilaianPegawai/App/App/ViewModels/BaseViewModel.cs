using App.Helpers;
using App.Models;
using App.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<pegawai> PegawaiDataStore => DependencyService.Get<IDataStore<pegawai>>();
        public IDataStore<penilaian> PenilaianDataStore => DependencyService.Get <IDataStore<penilaian>>();
        public IDataStore<detailpenilaian> DetailPenilaianDataStore => DependencyService.Get<IDataStore<detailpenilaian>>();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ICommand ShowProfile { get; set; }

    }
}

