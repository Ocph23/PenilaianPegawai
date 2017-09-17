using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.ViewModels.Details
{
    public class PenilaianViewModel : BaseViewModel
    {
        private pegawai _pegawai;

        public pegawai Pegawai {
            get { return _pegawai; }
            set
            {
                SetProperty(ref _pegawai, value);
            }
        }

        public PenilaianViewModel(pegawai item)
        {
            this.Pegawai= item;
        }
    }
}
