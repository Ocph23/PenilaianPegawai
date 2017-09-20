using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class detailpegawai : BaseDataObject
    {
        public int NIP
        {
            get { return _nip; }
            set
            {
                SetProperty(ref _nip, value);
            }
        }

        public DateTime TamatCPNS
        {
            get { return _tamatcpns; }
            set
            {
                SetProperty(ref _tamatcpns, value);
            }
        }

        public DateTime TamatGolongan
        {
            get { return _tamatgolongan; }
            set
            {
                SetProperty(ref _tamatgolongan, value);
            }
        }

        public DateTime TamatJabatan
        {
            get { return _tamatjabatan; }
            set
            {
                SetProperty(ref _tamatjabatan, value);
            }
        }

        public int TanggunganSuamiIstri
        {
            get { return _tanggungansuamiistri; }
            set
            {
                SetProperty(ref _tanggungansuamiistri, value);
            }
        }

        public int TanggunganAnak
        {
            get { return _tanggungananak; }
            set
            {
                SetProperty(ref _tanggungananak, value);
            }
        }

        public string SKPejabat
        {
            get { return _skpejabat; }
            set
            {
                SetProperty(ref _skpejabat, value);
            }
        }

        public string NomorSK
        {
            get { return _nomorsk; }
            set
            {
                SetProperty(ref _nomorsk, value);
            }
        }

        public DateTime TanggalSK
        {
            get { return _tanggalsk; }
            set
            {
                SetProperty(ref _tanggalsk, value);
            }
        }

        public int MasaKerja
        {
            get { return _masakerja; }
            set
            {
                SetProperty(ref _masakerja, value);
            }
        }

        public string JenisKepegawaian
        {
            get { return _jeniskepegawaian; }
            set
            {
                SetProperty(ref _jeniskepegawaian, value);
            }
        }

        public string StatusKepegawaian
        {
            get { return _statuskepegawaian; }
            set
            {
                _statuskepegawaian = value;
                
            }
        }

      

        private int _nip;
        private DateTime _tamatcpns;
        private DateTime _tamatgolongan;
        private DateTime _tamatjabatan;
        private int _tanggungansuamiistri;
        private int _tanggungananak;
        private string _skpejabat;
        private string _nomorsk;
        private DateTime _tanggalsk;
        private int _masakerja;
        private string _jeniskepegawaian;
        private string _statuskepegawaian;
      
    }
}
