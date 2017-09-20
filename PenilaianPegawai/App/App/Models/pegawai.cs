using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class pegawai : BaseDataObject
    {
        public int NIP
        {
            get { return _nip; }
            set
            {
                SetProperty(ref _nip,value);
            }
        }

        public string Nama
        {
            get { return _nama; }
            set
            {
                SetProperty(ref _nama, value);
            }
        }

        public string TempatLahir
        {
            get { return _tempatlahir; }
            set
            {
                SetProperty(ref _tempatlahir, value);
            }
        }

        public DateTime TanggalLahir
        {
            get { return _tanggallahir; }
            set
            {
                SetProperty(ref _tanggallahir, value);
            }
        }

        public string NomorKartuPegawai
        {
            get { return _nomorkartupegawai; }
            set
            {
                SetProperty(ref _nomorkartupegawai, value);
            }
        }

        public string Pendidikan
        {
            get { return _pendidikan; }
            set
            {
                SetProperty(ref _pendidikan, value);
            }
        }

        public string PangkatGolonganTerakhir
        {
            get { return _pangkatgolonganterakhir; }
            set
            {
                SetProperty(ref _pangkatgolonganterakhir, value);
            }
        }

        public string JabatanAkhir
        {
            get { return _jabatanakhir; }
            set
            {
                SetProperty(ref _jabatanakhir, value);
            }
        }

        public string Asal
        {
            get { return _asal; }
            set
            {
                SetProperty(ref _asal, value);
            }
        }

        public string JenisKelamin
        {
            get { return _jeniskelamin; }
            set
            {
                SetProperty(ref _jeniskelamin, value);
            }
        }

        public byte[] Foto
        {
            get { return _foto; }
            set
            {
                SetProperty(ref _foto, value);
            }
        }

        public string TTL
        {
            get
            {
                return this.TempatLahir + ", " + string.Format("{0}/{1}/{2}", this.TanggalLahir.Day, this.TanggalLahir.Month, this.TanggalLahir.Year);
            }
        }

        public detailpegawai Detail { get; set; }
        public penilaian HasilPenilaian { get; set; }

        private int _nip;
        private string _nama;
        private string _tempatlahir;
        private DateTime _tanggallahir;
        private string _nomorkartupegawai;
        private string _pendidikan;
        private string _pangkatgolonganterakhir;
        private string _jabatanakhir;
        private string _asal;
        private string _jeniskelamin;
        private byte[] _foto;
    }
}
