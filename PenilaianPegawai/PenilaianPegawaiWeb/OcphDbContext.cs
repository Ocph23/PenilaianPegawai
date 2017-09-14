using DAL.DContext;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PenilaianPegawaiWeb.DataModels;

namespace PenilaianPegawaiWeb
{
    public class OcphDbContext : IDbContext, IDisposable
    {
        private string ConnectionString;
        private IDbConnection _Connection;

        public OcphDbContext()
        {

            this.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IRepository<pegawai> Pegawai { get { return new Repository<pegawai>(this); } }
        public IRepository<detailpegawai> PegawaiDetail{ get { return new Repository<detailpegawai>(this); } }
        public IRepository<detailpenilaian> DetailPenilaian { get { return new Repository<detailpenilaian>(this); } }
        public IRepository<penilaian> Penilaian { get { return new Repository<penilaian>(this); } }
        public IRepository<pejabatpenilai> PejabatPenilai { get { return new Repository<pejabatpenilai>(this); } }
        public IRepository<kriteriapenilaian> KriteriaPenilaian{ get { return new Repository<kriteriapenilaian>(this); } }

        public IDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new MySqlDbContext(this.ConnectionString);
                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

      

        public void Dispose()
        {
            if (_Connection != null)
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
        }
    }
}
