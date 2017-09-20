using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace PenilaianPegawaiWeb.Models
{
    public class Periode:BaseNotifyProperty
    {
        private int _tahun;
        private int _tahap;

        public int Tahun
        {
            get
            {
                return _tahun;
            }
            set
            {
                _tahun = value;
                OnPropertyChange("Tahun");
            }
        }

        public int Tahap
        {
            get
            {
                return _tahap;
            }
            set
            {
                _tahap= value;
                OnPropertyChange("Tahap");
            }
        }

        public int Value
        {
            get { return Convert.ToInt32(string.Format("{0}{1}",Tahun,Tahap)); }
        }

    }
}