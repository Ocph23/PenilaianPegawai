using PenilaianPegawaiWeb.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PenilaianPegawaiWeb.Apis
{
    public class PegawaiController : ApiController
    {
        // GET: api/Pegawai
        public IEnumerable<pegawai> Get()
        {
            PegawaiCollection coll = new PegawaiCollection(2017);
            return coll.Pegawais();
        }

        // GET: api/Pegawai/5
        public HttpResponseMessage Get(int id)
        {
            PegawaiCollection coll = new PegawaiCollection(2017);
            var value = coll.Pegawai(id);
            if (value != null)
                return Request.CreateResponse(HttpStatusCode.OK, value);
            else
                return  Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
        }

        // POST: api/Pegawai
        public HttpResponseMessage Post(pegawai p)
        {
            PegawaiCollection coll = new PegawaiCollection(2017);
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


        public HttpResponseMessage PutPegawai(pegawai p)
        {
            PegawaiCollection coll = new PegawaiCollection(2017);
            try
            {
                if (p != null && coll.Update(p) != null)
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
            PegawaiCollection coll = new PegawaiCollection(2017);
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
                    if (db.Pegawai.Delete(O=>O.NIP==id))
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
