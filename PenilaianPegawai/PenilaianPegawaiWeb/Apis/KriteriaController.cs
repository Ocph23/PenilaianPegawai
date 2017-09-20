using PenilaianPegawaiWeb.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PenilaianPegawaiWeb.Apis
{
    public class KriteriaController : ApiController
    {
        // GET: api/Kriteria
        public IEnumerable<kriteriapenilaian> Get()
        {
            using (var db = new OcphDbContext())
            {
                return db.KriteriaPenilaian.Select();
            }
        }

        // GET: api/Kriteria/5
        public HttpResponseMessage Get(int id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var data = db.KriteriaPenilaian.Select();
                    if (data.Count() > 0)
                       return Request.CreateResponse(HttpStatusCode.OK, data);
                    else
                        throw new SystemException("Data tidak ditemukan");
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
              
            }
        }

        // POST: api/Kriteria
        public HttpResponseMessage Post(kriteriapenilaian penilaian)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new OcphDbContext())
                    {
                        penilaian.IdKriteria = db.KriteriaPenilaian.InsertAndGetLastID(penilaian);
                        if (penilaian.IdKriteria > 0)
                            return Request.CreateResponse(HttpStatusCode.OK, penilaian);
                        else
                            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Data Gagal Ditambah");
                    }
                }else
                {
                    var errors = Helpers.GetModelStateError(ModelState);
                    return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
                }
              
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }

        // PUT: api/Kriteria/5
        public HttpResponseMessage Put(kriteriapenilaian kriteria)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    if (db.KriteriaPenilaian.Update(O => new { O.Nama,O.Keterangan }, kriteria, o => o.IdKriteria == kriteria.IdKriteria))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, kriteria);
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Data Tidak Dapat Diubah");

                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // DELETE: api/Kriteria/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var isDeleted = db.KriteriaPenilaian.Delete(O => O.IdKriteria == id);
                    if(isDeleted)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Data Gagal");
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Data Tidak Dapat Dihapus");
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }

        }
    }
}
