using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PenilaianPegawaiWeb.Apis
{
    public class PejabatPenilaiController : ApiController
    {
        // GET: api/PejabatPenilai
        public IEnumerable<DataModels.pejabatpenilai> Get()
        {

            using (var db = new OcphDbContext())
            {
                var result = from a in db.PejabatPenilai.Select()
                             join b in db.Pegawai.Select() on a.NIP equals b.NIP
                             select new DataModels.pejabatpenilai { Id = a.Id, NIP = a.NIP, UserId = a.UserId, Pegawai = b };

                return result.ToList();
            }
        }

        // GET: api/PejabatPenilai/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PejabatPenilai
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PejabatPenilai/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PejabatPenilai/5
        public void Delete(int id)
        {
        }
    }
}
