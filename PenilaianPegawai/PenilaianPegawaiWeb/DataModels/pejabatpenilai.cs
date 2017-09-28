using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("pejabatpenilai")] 
     public class pejabatpenilai:BaseNotifyProperty  
   {
        [DbColumn("IdPegawai")]

        public int IdPegawai
        {
            get { return _IdPegawai; }
            set
            {
                _IdPegawai = value;
                OnPropertyChange("IdPegawai");
            }
        }

        [DbColumn("UserId")] 
          public string UserId 
          { 
               get{return _userid;} 
               set{ 
                      _userid=value; 
                     OnPropertyChange("UserId");
                     }
          } 

          [PrimaryKey("Id")] 
          [DbColumn("Id")] 
          public int Id 
          { 
               get{return _id;} 
               set{ 
                      _id=value; 
                     OnPropertyChange("Id");
                     }
          }
        [DbColumn("Aktif")]
        public bool Aktif
        {
            get { return _aktif; }
            set
            {
                _aktif = value;
                OnPropertyChange("Aktif");
            }
        }
        public pegawai Pegawai { get;  set; }

        private int  _nip;
           private string  _userid;
           private int  _id;
        private int _IdPegawai;
        private bool _aktif;
    }
}


