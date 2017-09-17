namespace App.Models
{
    public class kriteriapenilaian :BaseDataObject
    {
        public int IdKriteria
        {
            get { return _idkriteria; }
            set
            {
                SetProperty(ref _idkriteria, value);
            }
        }

        public string Nama
        {
            get { return _nama; }
            set
            {
                SetProperty(ref _nama, value);
            }
        }
        public string Keterangan
        {
            get { return _keterangan; }
            set
            {
                SetProperty(ref _keterangan, value);
            }
        }

        private int _idkriteria;
        private string _nama;
        private string _keterangan;
    }
}