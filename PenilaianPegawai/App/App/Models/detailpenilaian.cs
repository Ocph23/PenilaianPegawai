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

        public double Nilai
        {
            get { return _nilai; }
            set
            {
                SetProperty(ref _nilai, value);
             
                
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