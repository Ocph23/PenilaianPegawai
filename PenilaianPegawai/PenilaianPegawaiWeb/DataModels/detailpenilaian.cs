using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
 
 namespace PenilaianPegawaiWeb.DataModels 
{ 
     [TableName("detailpenilaian")] 
     public class detailpenilaian:BaseNotifyProperty  
   {

        [PrimaryKey("Id")]
        [DbColumn("Id")]
        public int Id
        {
            get { return _id; }
            set
            {
                _id= value;
                OnPropertyChange("Id");
            }
        }
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

          [DbColumn("Nilai")] 
          public double Nilai 
          { 
               get{return _nilai;} 
               set{ 
                      _nilai=value; 
                     OnPropertyChange("Nilai");
                     }
          }

        public kriteriapenilaian Kriteria { get; internal set; }

        private int  _idpenilaian;
           private int  _idkriteria;
           private double  _nilai;
        private int _id;
    }
}


