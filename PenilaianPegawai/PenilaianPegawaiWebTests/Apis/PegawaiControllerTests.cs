using Microsoft.VisualStudio.TestTools.UnitTesting;
using PenilaianPegawaiWeb.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using PenilaianPegawaiWeb.DataModels;

namespace PenilaianPegawaiWeb.Apis.Tests
{
    [TestClass()]
    public class PegawaiControllerTests
    {
        PegawaiController pegawai = new PegawaiController();

        [TestMethod()]
        public void GetTest()
        {
            var result = pegawai.Get();

            Assert.AreEqual(true,result.Count()>0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            pegawai.Request = new HttpRequestMessage();
            pegawai.Configuration = new HttpConfiguration();
            var result = pegawai.Get(123456789);
            Assert.AreEqual(true, result.IsSuccessStatusCode);
           
        }

        [TestMethod()]
        public void PostTest()
        {
            pegawai.Request = new HttpRequestMessage();
            pegawai.Configuration = new HttpConfiguration();
            pegawai p = new pegawai
            {
                Asal =  Asal.Papua,
                JabatanAkhir = "Direktur",
                JenisKelamin =  JenisKelamin.L,
                Nama = "Yaquin",
                NIP = 123456789,
                NomorKartuPegawai = "1234565", PangkatGolonganTerakhir = "IVA", Pendidikan =  Pendidikan.S1
                , TanggalLahir = new DateTime(), TempatLahir = "Jayapura"
            };

            var result = pegawai.Post(p);
            Assert.AreEqual(true, result.IsSuccessStatusCode);

        }

        [TestMethod()]
        public void PutPegawaiTest()
        {
            pegawai.Request = new HttpRequestMessage();
            pegawai.Configuration = new HttpConfiguration();
            pegawai p = new pegawai
            {
                Asal = Asal.Papua,
                JabatanAkhir = "Direktur",
                JenisKelamin =  JenisKelamin.P,
                Nama = "Yaquin",
                NIP = 123456789,
                NomorKartuPegawai = "1234565",
                PangkatGolonganTerakhir = "IIA",
                Pendidikan =  Pendidikan.S1
                ,
                TanggalLahir = new DateTime(),
                TempatLahir = "Jayapura"
            };

            var result = pegawai.PutPegawai(p);
            Assert.AreEqual(true, result.IsSuccessStatusCode);

        }

        [TestMethod()]
        public void PutPegawaiDetailTest()
        {
            pegawai.Request = new HttpRequestMessage();
            pegawai.Configuration = new HttpConfiguration();
            detailpegawai p = new detailpegawai
            {
                JenisKepegawaian = JenisKepegawaian.PNSD,
                MasaKerja = 25,
                NIP = 123456789,
                NomorSK = "1234567",
                SKPejabat = SKPejabat.Presiden, StatusKepegawaian = StatusKepegawaian.CPNS, TamatCPNS = new DateTime(), TamatGolongan = new DateTime(),
                TamatJabatan = new DateTime(), TanggalSK = new DateTime(), TanggunganAnak=2, TanggunganSuamiIstri=1 
            };

            var result = pegawai.PutDetailPegawai(p);
            Assert.AreEqual(true, result.IsSuccessStatusCode);

        }

        [TestMethod()]
        public void DeletePegawaiTest()
        {
            pegawai.Request = new HttpRequestMessage();
            pegawai.Configuration = new HttpConfiguration();
            var result = pegawai.Delete(123456789);
            Assert.AreEqual(true, result.IsSuccessStatusCode);

        }



    }
}