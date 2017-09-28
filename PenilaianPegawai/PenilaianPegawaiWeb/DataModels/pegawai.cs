using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("pegawai")] 
     public class pegawai:BaseNotifyProperty  
   {
          [PrimaryKey("IdPegawai")]
        [DbColumn("IdPegawai")] 
         
          public int IdPegawai
          { 
               get{return _IdPegawai; } 
               set{
                     _IdPegawai = value; 
                     OnPropertyChange("IdPegawai");
                     }
          } 

          [DbColumn("Nama")] 
          public string Nama 
          { 
               get{return _nama;} 
               set{ 
                      _nama=value; 
                     OnPropertyChange("Nama");
                     }
          }

        [DbColumn("NIP")]
        public string NIP
        {
            get { return _nip; }
            set
            {
                _nip = value;
                OnPropertyChange("NIP");
            }
        }

        [DbColumn("TempatLahir")] 
          public string TempatLahir 
          { 
               get{return _tempatlahir;} 
               set{ 
                      _tempatlahir=value; 
                     OnPropertyChange("TempatLahir");
                     }
          } 

          [DbColumn("TanggalLahir")] 
          public DateTime TanggalLahir 
          { 
               get{return _tanggallahir;} 
               set{ 
                      _tanggallahir=value; 
                     OnPropertyChange("TanggalLahir");
                     }
          } 

          [DbColumn("NomorKartuPegawai")] 
          public string NomorKartuPegawai 
          { 
               get{return _nomorkartupegawai;} 
               set{ 
                      _nomorkartupegawai=value; 
                     OnPropertyChange("NomorKartuPegawai");
                     }
          } 

          [DbColumn("Pendidikan")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Pendidikan Pendidikan 
          { 
               get{return _pendidikan;} 
               set{ 
                      _pendidikan=value; 
                     OnPropertyChange("Pendidikan");
                     }
          } 

          [DbColumn("PangkatGolonganTerakhir")] 
          public string PangkatGolonganTerakhir 
          { 
               get{return _pangkatgolonganterakhir;} 
               set{ 
                      _pangkatgolonganterakhir=value; 
                     OnPropertyChange("PangkatGolonganTerakhir");
                     }
          } 

          [DbColumn("JabatanAkhir")] 
          public string JabatanAkhir 
          { 
               get{return _jabatanakhir;} 
               set{ 
                      _jabatanakhir=value; 
                     OnPropertyChange("JabatanAkhir");
                     }
          } 

          [DbColumn("Asal")] 
          [JsonConverter(typeof(StringEnumConverter))]
          public Asal Asal 
          { 
               get{return _asal;} 
               set{ 
                      _asal=value; 
                     OnPropertyChange("Asal");
                     }
          } 

          [DbColumn("JenisKelamin")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JenisKelamin JenisKelamin 
          { 
               get{return _jeniskelamin;} 
               set{ 
                      _jeniskelamin=value; 
                     OnPropertyChange("JenisKelamin");
                     }
          }

        [DbColumn("Foto")]
        public byte[] Foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
                OnPropertyChange("Foto");
            }
        }

        [DbColumn("Aktif")]
        public bool Aktif
        {
            get { return _aktif; }
            set
            {
                _aktif= value;
                OnPropertyChange("Aktif");
            }
        }
        public string TTL
        {
            get
            {
                return this.TempatLahir + ", " + this.TanggalLahir.ToShortDateString();
            }
        }

        public detailpegawai Detail { get; set; }
        public penilaian HasilPenilaian { get; set; }

        private string  _nip;
           private string  _nama;
           private string  _tempatlahir;
           private DateTime  _tanggallahir;
           private string  _nomorkartupegawai;
           private Pendidikan  _pendidikan;
           private string  _pangkatgolonganterakhir;
           private string  _jabatanakhir;
           private Asal  _asal;
           private JenisKelamin _jeniskelamin;
            private byte[] _foto;
            private int _IdPegawai;
        private bool _aktif;
    }
}


