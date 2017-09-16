using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("pegawai")] 
     public class pegawai:BaseNotifyProperty  
   {
          [PrimaryKey("NIP")] 
          [DbColumn("NIP")] 
          public int NIP 
          { 
               get{return _nip;} 
               set{ 
                      _nip=value; 
                     OnPropertyChange("NIP");
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
          public string Pendidikan 
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
          public string Asal 
          { 
               get{return _asal;} 
               set{ 
                      _asal=value; 
                     OnPropertyChange("Asal");
                     }
          } 

          [DbColumn("JenisKelamin")] 
          public string JenisKelamin 
          { 
               get{return _jeniskelamin;} 
               set{ 
                      _jeniskelamin=value; 
                     OnPropertyChange("JenisKelamin");
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

        private int  _nip;
           private string  _nama;
           private string  _tempatlahir;
           private DateTime  _tanggallahir;
           private string  _nomorkartupegawai;
           private string  _pendidikan;
           private string  _pangkatgolonganterakhir;
           private string  _jabatanakhir;
           private string  _asal;
           private string  _jeniskelamin;
      }
}


