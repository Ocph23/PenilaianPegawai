using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("penilaian")] 
     public class penilaian:BaseNotifyProperty  
   {
          [PrimaryKey("IdPenilaian")] 
          [DbColumn("IdPenilaian")] 
          public int IdPenilaian 
          { 
               get{return _idpenilaian;} 
               set{ 
                      _idpenilaian=value; 
                     OnPropertyChange("IdPenilaian");
                     }
          } 

          [DbColumn("TahunPeriode")] 
          public int TahunPeriode 
          { 
               get{return _tahunperiode;} 
               set{ 
                      _tahunperiode=value; 
                     OnPropertyChange("TahunPeriode");
                     }
          } 

          [DbColumn("NIP")] 
          public int NIP 
          { 
               get{return _nip;} 
               set{ 
                      _nip=value; 
                     OnPropertyChange("NIP");
                     }
          } 

          [DbColumn("PejabatPenilaiId")] 
          public int PejabatPenilaiId 
          { 
               get{return _pejabatpenilaiid;} 
               set{ 
                      _pejabatpenilaiid=value; 
                     OnPropertyChange("PejabatPenilaiId");
                     }
          }

        public pegawai PejabatPenilai { get; internal set; }
        public List<detailpenilaian> DaftarPenilaian { get; internal set; }
        public pegawai Pegawai { get; internal set; }

        private int  _idpenilaian;
           private int  _tahunperiode;
           private int  _nip;
           private int  _pejabatpenilaiid;
      }
}


