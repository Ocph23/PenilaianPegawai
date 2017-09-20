using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(StringEnumConverter))]
        public SKPejabat SKPejabat 
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
        [JsonConverter(typeof(StringEnumConverter))]
        public JenisKepegawaian JenisKepegawaian 
          { 
               get{return _jeniskepegawaian;} 
               set{ 
                      _jeniskepegawaian=value; 
                     OnPropertyChange("JenisKepegawaian");
                     }
          } 

          [DbColumn("StatusKepegawaian")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusKepegawaian StatusKepegawaian 
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
           private SKPejabat  _skpejabat;
           private string  _nomorsk;
           private DateTime  _tanggalsk;
           private int  _masakerja;
           private JenisKepegawaian  _jeniskepegawaian;
           private StatusKepegawaian  _statuskepegawaian;
      }
}


