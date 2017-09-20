using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace PenilaianPegawaiWeb
{
    public static class Helpers
    {
        public static Models.Periode GetPeriode(DateTime tanggal)
        {
            var tahap = GetTahap(tanggal.Month);
            var data = new Models.Periode { Tahun = tanggal.Year, Tahap=tahap };
            return data;
        }

        private static int GetTahap(int month)
        {
            if (month <= 3)
            {
                return 1;
            }
            else if (month > 3 && month <= 6)
            {
                return 2;
            }
            else if (month > 6 && month <= 9)
                return 3;
            else
                return 4;
        }


        public static Models.Periode ConvertToPeriode(int tahunperiode)
        {
            var data = tahunperiode.ToString();
            var tahun =Convert.ToInt32( data.Substring(0, 4));
            var tahap =Convert.ToInt32( data.Substring(4, 1));
            return new Models.Periode { Tahap = tahap, Tahun = tahun };
        }

        public static byte[] ResizeImage(byte[] images, int width)
        {
            byte[] imageBytes;

            //Of course image bytes is set to the bytearray of your image      

            using (MemoryStream ms = new MemoryStream(images, 0, images.Length))
            {
                using (Image img = Image.FromStream(ms))
                {


                    using (Bitmap b = new Bitmap(img, new Size(width, width)))
                    {
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageBytes = ms2.ToArray();
                        }
                    }
                }
            }

            return imageBytes;
        }

        public static List<string> GetModelStateError(ModelStateDictionary modelState)
        {
           var errors= new List<string>();
            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }
    }
}