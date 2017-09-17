namespace App.Models
{
    public class detailpenilaian :BaseDataObject
    {
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

        public kriteriapenilaian Kriteria { get; internal set; }

        private int _idpenilaian;
        private int _idkriteria;
        private double _nilai;
    }
}