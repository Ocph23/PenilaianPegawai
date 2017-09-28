using System;
using System.Threading.Tasks;
using App.Helpers;
using Xamarin.Forms;
using App.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace App.Models
{
    public class detailpenilaian :ViewModels.BaseViewModel
    {

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }
        public int IdPenilaian
        {
            get { return _idpenilaian; }
            set
            {
                SetProperty(ref _idpenilaian, value);
            }
        }

        public int IdKriteria
        {
            get { return _idkriteria; }
            set
            {
                SetProperty(ref _idkriteria, value);
            }
        }

        private bool first=true;

        public double Nilai
        {
            get { return _nilai; }
            set
            {
              
               if(first)
                {
                    first = false;
                    SetProperty(ref _nilai, value);
                }
                else
                {
                    if(value!=_nilai && value >9 && value <=100)
                    {
                        SetProperty(ref _nilai, value);
                        DetailPenilaianDataStore.UpdateItemAsync(this);
                    }
                    else if(value>100)
                    {
                        MessagingCenter.Send(new MessagingCenterAlert
                        {
                            Title = "Error",
                            Message = "Maksimum penilaian 100",
                            Cancel = "OK"
                        }, "message");
                    }
                    else if(value!=_nilai)
                    {

                        SetProperty(ref _nilai, value);
                    }
                    
                }


            }
        }

    

        public kriteriapenilaian Kriteria
        {
            get { return _kriteria; }
            set { SetProperty(ref _kriteria, value); }
        }

        private int _idpenilaian;
        private int _idkriteria;
        private double _nilai;
        private int _id;
        private kriteriapenilaian _kriteria;
    }
}