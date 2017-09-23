using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PenilaianPegawaiWeb.Apis
{

    [Authorize(Roles = "Administrator")]
    public class PhotoController : ApiController
    {
        //  [ResponseType(typeof(Foto))]
        [HttpPost]

        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable,
                    "This request is not properly formatted"));
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var p = new DataModels.pegawai();

                foreach (HttpContent ctnt in provider.Contents)
                {
                    var name = ctnt.Headers.ContentDisposition.Name;
                    var field = name.Substring(1, name.Length - 2);
                    if (field == "file")
                    {
                        //now read individual part into STREAM
                        var stream = await ctnt.ReadAsStreamAsync();

                        byte[] data = new byte[stream.Length];

                        if (stream.Length != 0)
                        {
                            await stream.ReadAsync(data, 0, (int)stream.Length);
                            p.Foto = Helpers.ResizeImage(data, 150);
                        }
                    }
                    else if (field == "IdPegawai")
                    {
                        p.IdPegawai = Convert.ToInt32(await ctnt.ReadAsStringAsync());
                    }
                }

                using (var db = new OcphDbContext())
                {
                    if (db.Pegawai.Update(O=>new { O.Foto},p,O=>O.IdPegawai==p.IdPegawai))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, p);
                    }else
                    {
                        throw new SystemException("Foto Gagal Diubah");
                    }
                }
              

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }



    }


}
