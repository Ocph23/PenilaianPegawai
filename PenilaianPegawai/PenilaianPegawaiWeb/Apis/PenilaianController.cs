using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using PenilaianPegawaiWeb.Models;
using PenilaianPegawaiWeb.DataModels;

namespace PenilaianPegawaiWeb.Apis
{
    public class PenilaianController : ApiController
    {
        // GET: api/Penilaian
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       // [Authorize]
        [HttpPost]
        public HttpResponseMessage GetByPeriode(Periode periode)
        {
            try
            {
                using (var db = new OcphDbContext())
                {

                    var kriterias = from a in db.DetailPenilaian.Select()
                                    join b in db.KriteriaPenilaian.Select() on a.IdKriteria equals b.IdKriteria
                                    select new detailpenilaian { Id = a.Id, IdKriteria = a.IdKriteria, IdPenilaian = a.IdPenilaian, Nilai = a.Nilai, Kriteria = b };



                    var result = (from b in db.Penilaian.Where(O => O.TahunPeriode == periode.Value)
                                  join a in db.Pegawai.Where(o => o.Aktif == true) on b.IdPegawai equals a.IdPegawai
                                  join f in db.PejabatPenilai.Select() on b.PejabatPenilaiId equals f.Id
                                  join c in kriterias on b.IdPenilaian equals c.IdPenilaian into cgroup
                                  select new penilaian
                                  {
                                      Pegawai = a,
                                      DaftarPenilaian = cgroup.ToList(),
                                      RataRata =Math.Round( cgroup.Sum(O => O.Nilai) / cgroup.Count(),2),
                                      TahunPeriode = b.TahunPeriode,
                                      IdPenilaian = b.IdPenilaian,
                                      IdPegawai = b.IdPegawai,
                                      PejabatPenilaiId = b.PejabatPenilaiId,
                                      PejabatPenilai = db.Pegawai.Where(O => O.IdPegawai ==f.IdPegawai).FirstOrDefault()
                                  }).ToList();



                    foreach(var item in db.PejabatPenilai.Where(O => O.Aktif == true))
                    {
                        result.RemoveAll(O => O.IdPegawai == item.IdPegawai);
                    }


                                return Request.CreateResponse(HttpStatusCode.OK, result.ToList().OrderByDescending(O=>O.RataRata));


                   


                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: api/Penilaian/5
      //  [Authorize]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                  
                    var pejabatui = User.Identity.GetUserId();
                    //var pejabatui = "0f62fa26-5aa7-4b00-a1da-217315324f5a";
                    if (string.IsNullOrEmpty(pejabatui))
                    {
                        throw new SystemException("Anda Tidak memiliki Akses");
                    }
                    else
                    {
                        var Nippejabat = db.PejabatPenilai.Where(O => O.UserId == pejabatui).FirstOrDefault();
                        if(Nippejabat==null)
                        {
                            throw new SystemException("Anda Tidak memiliki Akses");
                        }
                        else
                        {
                            var penialaian = db.Penilaian.Where(O => O.IdPegawai == id).FirstOrDefault();
                            if (penialaian == null)
                            {
                                penialaian = new DataModels.penilaian { IdPegawai = id, PejabatPenilaiId = Nippejabat.Id, TahunPeriode = Helpers.GetPeriode(DateTime.Now).Value };
                                penialaian.IdPenilaian= db.Penilaian.InsertAndGetLastID(penialaian);
                                penialaian.DaftarPenilaian = new List<DataModels.detailpenilaian>();
                                foreach(var item in db.KriteriaPenilaian.Select())
                                {
                                    var data = new DataModels.detailpenilaian { IdKriteria = item.IdKriteria, IdPenilaian = penialaian.IdPenilaian, Kriteria = item, Nilai = 0 };
                                   data.Id = db.DetailPenilaian.InsertAndGetLastID(data);
                                    penialaian.DaftarPenilaian.Add(data);
                                }
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
                                                 Kriteria = b, Id=a.Id,
                                                 Nilai = a.Nilai
                                             };
                                penialaian.DaftarPenilaian = result.ToList();
                                foreach (var item in db.KriteriaPenilaian.Select())
                                {
                                    if(penialaian.DaftarPenilaian.Where(O=>O.IdKriteria==item.IdKriteria).FirstOrDefault()==null)
                                    {
                                        var data = new DataModels.detailpenilaian { IdKriteria = item.IdKriteria, IdPenilaian = penialaian.IdPenilaian, Kriteria = item, Nilai = 0 };
                                        data.Id = db.DetailPenilaian.InsertAndGetLastID(data);
                                        penialaian.DaftarPenilaian.Add(data);
                                    }
                                   
                                }
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
        [HttpPost]
        public HttpResponseMessage Put(DataModels.detailpenilaian detail)
        {
            try
            {

                using (var db = new OcphDbContext())
                {
                    if (db.DetailPenilaian.Update(O => new { O.Nilai }, detail, O => O.Id == detail.Id))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, detail);
                    }
                    else
                        throw new SystemException("Data Gagal Diupdate");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotModified, ex);
            }
        }

        // DELETE: api/Penilaian/5
        public void Delete(int id)
        {
        }
    }
}
