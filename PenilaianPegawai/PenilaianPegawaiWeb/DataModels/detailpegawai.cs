using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("detailpegawai")] 
     public class detailpegawai:BaseNotifyProperty  
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

          [DbColumn("TamatCPNS")] 
          public DateTime TamatCPNS 
          { 
               get{return _tamatcpns;} 
               set{ 
                      _tamatcpns=value; 
                     OnPropertyChange("TamatCPNS");
                     }
          } 

          [DbColumn("TamatGolongan")] 
          public DateTime TamatGolongan 
          { 
               get{return _tamatgolongan;} 
               set{ 
                      _tamatgolongan=value; 
                     OnPropertyChange("TamatGolongan");
                     }
          } 

          [DbColumn("TamatJabatan")] 
          public DateTime TamatJabatan 
          { 
               get{return _tamatjabatan;} 
               set{ 
                      _tamatjabatan=value; 
                     OnPropertyChange("TamatJabatan");
                     }
          } 

          [DbColumn("TanggunganSuamiIstri")] 
          public int TanggunganSuamiIstri 
          { 
               get{return _tanggungansuamiistri;} 
               set{ 
                      _tanggungansuamiistri=value; 
                     OnPropertyChange("TanggunganSuamiIstri");
                     }
          } 

          [DbColumn("TanggunganAnak")] 
          public int TanggunganAnak 
          { 
               get{return _tanggungananak;} 
               set{ 
                      _tanggungananak=value; 
                     OnPropertyChange("TanggunganAnak");
                     }
          } 

          [DbColumn("SKPejabat")] 
          public string SKPejabat 
          { 
               get{return _skpejabat;} 
               set{ 
                      _skpejabat=value; 
                     OnPropertyChange("SKPejabat");
                     }
          } 

          [DbColumn("NomorSK")] 
          public string NomorSK 
          { 
               get{return _nomorsk;} 
               set{ 
                      _nomorsk=value; 
                     OnPropertyChange("NomorSK");
                     }
          } 

          [DbColumn("TanggalSK")] 
          public DateTime TanggalSK 
          { 
               get{return _tanggalsk;} 
               set{ 
                      _tanggalsk=value; 
                     OnPropertyChange("TanggalSK");
                     }
          } 

          [DbColumn("MasaKerja")] 
          public int MasaKerja 
          { 
               get{return _masakerja;} 
               set{ 
                      _masakerja=value; 
                     OnPropertyChange("MasaKerja");
                     }
          } 

          [DbColumn("JenisKepegawaian")] 
          public string JenisKepegawaian 
          { 
               get{return _jeniskepegawaian;} 
               set{ 
                      _jeniskepegawaian=value; 
                     OnPropertyChange("JenisKepegawaian");
                     }
          } 

          [DbColumn("StatusKepegawaian")] 
          public string StatusKepegawaian 
          { 
               get{return _statuskepegawaian;} 
               set{ 
                      _statuskepegawaian=value; 
                     OnPropertyChange("StatusKepegawaian");
                     }
          } 

           

          private int  _nip;
           private DateTime  _tamatcpns;
           private DateTime  _tamatgolongan;
           private DateTime  _tamatjabatan;
           private int  _tanggungansuamiistri;
           private int  _tanggungananak;
           private string  _skpejabat;
           private string  _nomorsk;
           private DateTime  _tanggalsk;
           private int  _masakerja;
           private string  _jeniskepegawaian;
           private string  _statuskepegawaian;
           private string  _detailpegawaicol;
      }
}


