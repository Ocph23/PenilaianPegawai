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
          [DbColumn("NIP")] 
          public int NIP 
          { 
               get{return _nip;} 
               set{ 
                      _nip=value; 
                     OnPropertyChange("NIP");
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

        public pegawai Pegawai { get;  set; }

        private int  _nip;
           private string  _userid;
           private int  _id;
      }
}

