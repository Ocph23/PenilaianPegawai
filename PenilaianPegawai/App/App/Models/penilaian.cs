using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class penilaian : BaseDataObject
    {
        public int IdPenilaian
        {
            get { return _idpenilaian; }
            set
            {
                SetProperty(ref _idpenilaian, value);
            }
        }

        public int TahunPeriode
        {
            get { return _tahunperiode; }
            set
            {
                SetProperty(ref _tahunperiode, value);
            }
        }

        public int NIP
        {
            get { return _nip; }
            set
            {
                SetProperty(ref _nip, value);
            }
        }

        public int PejabatPenilaiId
        {
            get { return _pejabatpenilaiid; }
            set
            {
                SetProperty(ref _pejabatpenilaiid, value);
            }
        }

        public pegawai PejabatPenilai { get; internal set; }
        public List<detailpenilaian> DaftarPenilaian { get; internal set; }
        public pegawai Pegawai { get; internal set; }

        private int _idpenilaian;
        private int _tahunperiode;
        private int _nip;
        private int _pejabatpenilaiid;
    }
}
