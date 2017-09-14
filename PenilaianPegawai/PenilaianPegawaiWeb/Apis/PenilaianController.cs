using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace PenilaianPegawaiWeb.Apis
{
    public class PenilaianController : ApiController
    {
        // GET: api/Penilaian
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Penilaian/5
        public HttpResponseMessage Get(int nip)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var pejabatui = User.Identity.GetUserId();
                    if (string.IsNullOrEmpty(pejabatui))
                    {
                        throw new SystemException("Anda Tidak memiliki Akses");
                    }
                    else
                    {
                        var Nippejabat = db.PejabatPenilai.Where(O => O.UserId == pejabatui).FirstOrDefault();
                        if(Nippejabat!=null)
                        {
                            throw new SystemException("Anda Tidak memiliki Akses");
                        }
                        else
                        {
                            var penialaian = db.Penilaian.Where(O => O.NIP == nip).FirstOrDefault();
                            if (penialaian == null)
                            {
                                var data = new DataModels.penilaian { NIP = nip, PejabatPenilaiId = Nippejabat.Id, TahunPeriode = DateTime.Now.Year };
                                data.IdPenilaian= db.Penilaian.InsertAndGetLastID(data);
                                data.DaftarPenilaian = new List<DataModels.detailpenilaian>();
                              return  Request.CreateResponse(HttpStatusCode.OK, penialaian);
                            }
                            else
                            {
                                var result = from a in db.DetailPenilaian.Where(O => O.IdPenilaian == penialaian.IdPenilaian)
                                             join b in db.KriteriaPenilaian.Select() on a.IdKriteria equals b.IdKriteria
                                             select new DataModels.detailpenilaian
                                             {
                                                 IdKriteria = a.IdKriteria,
                                                 IdPenilaian = a.IdPenilaian,
                                                 Kriteria = b,
                                                 Nilai = a.Nilai
                                             };
                                penialaian.DaftarPenilaian = result.ToList();
                               return Request.CreateResponse(HttpStatusCode.OK, penialaian);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // POST: api/Penilaian
        public HttpResponseMessage Post(DataModels.detailpenilaian detail)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var detailOnDb = db.DetailPenilaian.Where(O => O.IdPenilaian == detail.IdPenilaian && O.IdKriteria == detail.IdKriteria).FirstOrDefault();
                    if(detailOnDb!=null)
                    {
                       var isUpdated= db.DetailPenilaian.Update(O => new { O.Nilai }, detail, O => O.IdKriteria == detail.IdKriteria && O.IdPenilaian == detail.IdPenilaian);
                        if (isUpdated)
                            return Request.CreateResponse(HttpStatusCode.OK, detail);
                        else
                            return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Data Tidak Dapat diubah");
                    }else
                    {
                        var isInserted = db.DetailPenilaian.Insert(detail);
                        if (isInserted)
                            return Request.CreateResponse(HttpStatusCode.OK, detail);
                        else
                            return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Data Tidak Dapat diubah");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // PUT: api/Penilaian/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Penilaian/5
        public void Delete(int id)
        {
        }
    }
}
