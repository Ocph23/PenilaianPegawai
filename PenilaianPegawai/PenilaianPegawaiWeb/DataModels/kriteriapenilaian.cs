using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("kriteriapenilaian")] 
     public class kriteriapenilaian:BaseNotifyProperty  
   {
          [PrimaryKey("IdKriteria")] 
          [DbColumn("IdKriteria")] 
          public int IdKriteria 
          { 
               get{return _idkriteria;} 
               set{ 
                      _idkriteria=value; 
                     OnPropertyChange("IdKriteria");
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
        [DbColumn("Keterangan")]
        public string Keterangan
        {
            get { return _keterangan; }
            set
            {
                _keterangan = value;
                OnPropertyChange("Keterangan");
            }
        }

        private int  _idkriteria;
           private string  _nama;
        private string _keterangan;
    }
}


