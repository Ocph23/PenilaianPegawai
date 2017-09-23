using PenilaianPegawaiWeb.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace PenilaianPegawaiWeb.Apis
{
    public class PegawaiController : ApiController
    {
        // GET: api/Pegawai
        public IEnumerable<pegawai> Get()
        {
            var periode = Helpers.GetPeriode(DateTime.Now);
            PegawaiCollection coll = new PegawaiCollection(periode.Value);
            return coll.Pegawais();
        }

        // GET: api/Pegawai/5
        public HttpResponseMessage Get(int id)
        {
            var periode = Helpers.GetPeriode(DateTime.Now);
            PegawaiCollection coll = new PegawaiCollection(periode.Value);
            var value = coll.Pegawai(id);
            if (value != null)
                return Request.CreateResponse(HttpStatusCode.OK, value);
            else
                return  Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
        }


        [Authorize(Roles = "Penilai")]
        [HttpGet]
        public HttpResponseMessage GetPenilaiProfile()
        {
            var id = User.Identity.GetUserId();
            var periode = Helpers.GetPeriode(DateTime.Now);
            PegawaiCollection coll = new PegawaiCollection(periode.Value);
            pejabatpenilai penilai = null;
            using (var db = new OcphDbContext())
            {
                penilai = db.PejabatPenilai.Where(O => O.UserId == id).FirstOrDefault();
            }
            if (penilai != null)
            {
                var pegawai = coll.Pegawai(penilai.IdPegawai);
                if (pegawai != null)
                    return Request.CreateResponse(HttpStatusCode.OK, pegawai);
                else
                {
                    throw new SystemException("Profile Tidak Ditemukan");
                }
            }
            else
                throw new SystemException("User Bukan Pejabat Penilai");
        }

        // POST: api/Pegawai
        public HttpResponseMessage Post(pegawai p)
        {
            if(ModelState.IsValid)
            {
                var periode = Helpers.GetPeriode(DateTime.Now);
                PegawaiCollection coll = new PegawaiCollection(periode.Value);
                try
                {
                    if (p != null && coll.Insert(p) != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, p);
                    }
                    else
                        throw new SystemException("Data  Gagal Ditambah");
                }
                catch (Exception ex)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                }
            }
            else
            {
                var errors = Helpers.GetModelStateError(ModelState);
                return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
            }
           
        }


        public HttpResponseMessage PutPegawai(pegawai p)
        {
            var periode = Helpers.GetPeriode(DateTime.Now);
            PegawaiCollection coll = new PegawaiCollection(periode.Value);
            try
            {
                if(p!=null && p.Detail!=null)
                {
                    coll.Update(p.Detail);
                }
                if (p != null && coll.Update(p))
                {
                    
                    return Request.CreateResponse(HttpStatusCode.OK, p);
                }
                else
                    throw new SystemException("Data  Gagal Ditambah");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public HttpResponseMessage PutDetailPegawai(detailpegawai p)
        {
            var periode = Helpers.GetPeriode(DateTime.Now);
            PegawaiCollection coll = new PegawaiCollection(periode.Value);
            try
            {
                if (p != null && coll.Update(p))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, p);
                }
                else
                    throw new SystemException("Data  Gagal Ditambah");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // PUT: api/Pegawai/5
       

        // DELETE: api/Pegawai/5
        public HttpResponseMessage Delete(int id)
        {

            using (var db = new OcphDbContext())
            {
                try
                {
                    if (db.Pegawai.Delete(O=>O.IdPegawai==id))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, true);
                    }
                    else
                        throw new SystemException("Data  Gagal Ditambah");
                }
                catch (Exception ex)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                }
            }
        }
    }
}
