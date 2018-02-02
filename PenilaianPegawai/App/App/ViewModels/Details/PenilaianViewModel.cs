using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Xamarin.Forms;
using App.Helpers;

namespace App.ViewModels.Details
{
    public class PenilaianViewModel : BaseViewModel
    {
        private pegawai _pegawai;
        private penilaian _penilaian;
        private detailpenilaian _selected;
        private Command _tapCommand;
        public PenilaianViewModel(pegawai item)
        {
            this.Pegawai = item;
            this.GetPenilaian(item.IdPegawai);
        }

        public detailpenilaian SelectedItem {
            get
            {
                return _selected;
            }
            set
            {
                SetProperty(ref _selected,value);
            }

        }

        public pegawai Pegawai {
            get { return _pegawai; }
            set
            {
                SetProperty(ref _pegawai, value);
            }
        }

        public penilaian Penilaian {
            get { return _penilaian; }
            set
            {
                SetProperty(ref _penilaian, value);
            }
        }

       

        private async void GetPenilaian(int nIP)
        {
            this.Penilaian = await PenilaianDataStore.GetItemAsync(nIP.ToString());
        }

        public void UpdateDB()
        {
         //   DetailPenilaianDataStore.UpdateItemAsync(SelectedItem);
        }
    }
}
