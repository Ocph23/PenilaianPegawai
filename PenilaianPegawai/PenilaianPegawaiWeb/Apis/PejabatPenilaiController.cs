using Microsoft.AspNet.Identity.Owin;
using PenilaianPegawaiWeb.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
                             join b in db.Pegawai.Select() on a.IdPegawai equals b.IdPegawai
                             select new DataModels.pejabatpenilai { Aktif=a.Aktif, Id = a.Id, IdPegawai = a.IdPegawai, UserId = a.UserId, Pegawai = b };

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
        public async Task<HttpResponseMessage> Put(pejabatpenilai value)
        {

            using (var db = new OcphDbContext())
            {
                if (db.PejabatPenilai.Update(O => new { O.Aktif }, value, O => O.Id == value.Id))
                {
                    var _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    if (value.Aktif==false)
                    {
                       var user = await _userManager.FindByIdAsync(value.UserId);
                       await _userManager.SetLockoutEnabledAsync(user.Id, true);
                    }else
                    {
                        var user = await _userManager.FindByIdAsync(value.UserId);
                        await _userManager.SetLockoutEnabledAsync(user.Id, false);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }else
                    return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Tidak Dapat Diubah");
            }
        }

        // DELETE: api/PejabatPenilai/5
        public void Delete(int id)
        {
        }
    }
}
