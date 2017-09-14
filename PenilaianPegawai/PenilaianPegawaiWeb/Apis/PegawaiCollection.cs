using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PenilaianPegawaiWeb.DataModels;
using MySql.Data.MySqlClient;

namespace PenilaianPegawaiWeb.Apis
{
    public class PegawaiCollection
    {
        private int peroide;

        public PegawaiCollection(int periode)
        {
            this.peroide = periode;
        }

        public List<pegawai> Pegawais()
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Pegawai.Select()
                             join b in db.PegawaiDetail.Select() on a.NIP equals b.NIP into pegawaigrpup
                             from b in pegawaigrpup.DefaultIfEmpty()
                             select new pegawai
                             {
                                 Asal = a.Asal,
                                 JabatanAkhir = a.JabatanAkhir,
                                 JenisKelamin = a.JenisKelamin,
                                 Nama = a.Nama,
                                 NIP = a.NIP,
                                 NomorKartuPegawai = a.NomorKartuPegawai,
                                 PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                 Pendidikan = a.Pendidikan,
                                 TanggalLahir = a.TanggalLahir,
                                 TempatLahir = a.TempatLahir,
                                 Detail = b
                             };
                return result.ToList();
            }
        }

        internal pegawai Insert(pegawai p)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.Connection.BeginTransaction();
                try
                {
                    if (p != null)
                    {
                        var isInsertPegawai = db.Pegawai.Insert(p);
                        if (p.Detail != null)
                        {
                            var IsInsertDetail = db.PegawaiDetail.Insert(p.Detail);
                            if (!isInsertPegawai || !IsInsertDetail)
                                throw new SystemException("Data Tidak Dapat Disimpan");
                        }
                        trans.Commit();
                        return p;
                    }
                    else
                        throw new SystemException("Data Tidak valid");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        internal bool Update(detailpegawai p)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var detail = db.PegawaiDetail.Where(O => O.NIP == p.NIP).FirstOrDefault();
                    if(detail!=null)
                    {
                        return db.PegawaiDetail.Update(O => new
                        {
                            O.JenisKepegawaian,
                            O.MasaKerja,
                            O.NomorSK,
                            O.SKPejabat,
                            O.StatusKepegawaian,
                            O.TamatCPNS,
                            O.TamatGolongan,
                            O.TamatJabatan,
                            O.TanggalSK,
                            O.TanggunganAnak,
                            O.TanggunganSuamiIstri
                        }, p, O => O.NIP == p.NIP);
                    }else
                        return db.PegawaiDetail.Insert(p);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        internal bool Update(pegawai p)
        {

            using (var db = new OcphDbContext())
            {
                return db.Pegawai.Update(O => new
                {
                    O.Asal,
                    O.JabatanAkhir,
                    O.JenisKelamin,
                    O.Nama,
                    O.NomorKartuPegawai,
                    O.PangkatGolonganTerakhir,
                    O.Pendidikan,
                    O.TanggalLahir,
                    O.TempatLahir
                }, p, O => O.NIP == p.NIP);
            }
        }

        public pegawai Pegawai(int NIP)
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Pegawai.Where(O=>O.NIP==NIP)
                             join b in db.PegawaiDetail.Select() on a.NIP equals b.NIP into pegawaigrpup
                             from b in pegawaigrpup.DefaultIfEmpty()
                             select new pegawai
                             {
                                 Asal = a.Asal,
                                 JabatanAkhir = a.JabatanAkhir,
                                 JenisKelamin = a.JenisKelamin,
                                 Nama = a.Nama,
                                 NIP = a.NIP,
                                 NomorKartuPegawai = a.NomorKartuPegawai,
                                 PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                 Pendidikan = a.Pendidikan,
                                 TanggalLahir = a.TanggalLahir,
                                 TempatLahir = a.TempatLahir,
                                 Detail = b
                             };
                return result.FirstOrDefault();
            }
        }

        public List<pegawai> PenilaianPegawais(int periode)
        {
            try
            {
                if(periode==0)
                {
                    throw new SystemException("Periode Penilaian Belum Ditentukan");
                }else
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = from a in db.Pegawai.Select()
                                     join b in db.PegawaiDetail.Select() on a.NIP equals b.NIP into pegawaigrpup
                                     from b in pegawaigrpup.DefaultIfEmpty()
                                     select new pegawai
                                     {
                                         Asal = a.Asal,
                                         JabatanAkhir = a.JabatanAkhir,
                                         JenisKelamin = a.JenisKelamin,
                                         Nama = a.Nama,
                                         NIP = a.NIP,
                                         NomorKartuPegawai = a.NomorKartuPegawai,
                                         PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                         Pendidikan = a.Pendidikan,
                                         TanggalLahir = a.TanggalLahir,
                                         TempatLahir = a.TempatLahir,
                                         Detail = b
                                     };



                        var penilaians = from a in db.Penilaian.Where(o=>o.TahunPeriode==periode)
                                         join n in db.PejabatPenilai.Select() on a.NIP equals n.NIP
                                         join m in result on n.NIP equals m.NIP
                                         select new penilaian
                                         {
                                             IdPenilaian = a.IdPenilaian,
                                             NIP = a.NIP,
                                             PejabatPenilaiId = a.PejabatPenilaiId,
                                             TahunPeriode = a.TahunPeriode,
                                             PejabatPenilai = m
                                         };

                        var indetail = from c in db.DetailPenilaian.Select()
                                       join b in db.KriteriaPenilaian.Select() on c.IdKriteria equals b.IdKriteria
                                       select new detailpenilaian
                                       {
                                           IdKriteria = c.IdKriteria,
                                           IdPenilaian = c.IdPenilaian,
                                           Nilai = c.Nilai,
                                           Kriteria = b
                                       };

                        var realpenilaian = from a in penilaians
                                            join d in indetail on a.IdPenilaian equals d.IdPenilaian into k
                                            from
                                             d in k.DefaultIfEmpty()
                                            select new penilaian
                                            {
                                                DaftarPenilaian = k.ToList(),
                                                IdPenilaian = a.IdPenilaian,
                                                NIP = a.NIP,
                                                PejabatPenilai = a.PejabatPenilai,
                                                PejabatPenilaiId = a.PejabatPenilaiId,
                                                TahunPeriode = a.TahunPeriode,
                                            };
                                       ;


                        return (from a in result
                                join b in realpenilaian on a.NIP equals b.NIP
                                select new pegawai
                                {
                                    Asal = a.Asal,
                                    JabatanAkhir = a.JabatanAkhir,
                                    JenisKelamin = a.JenisKelamin,
                                    Nama = a.Nama,
                                    NIP = a.NIP,
                                    NomorKartuPegawai = a.NomorKartuPegawai,
                                    PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                    Pendidikan = a.Pendidikan,
                                    TanggalLahir = a.TanggalLahir,
                                    TempatLahir = a.TempatLahir,
                                    Detail = a.Detail, HasilPenilaian = b
                                }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
           
        }


        public pegawai PenilaianPegawai(int periode, int NIP)
        {
            try
            {
                if (periode == 0)
                {
                    throw new SystemException("Periode Penilaian Belum Ditentukan");
                }
                else
                {
                    using (var db = new OcphDbContext())
                    {
                        var result = from a in db.Pegawai.Where(O=>O.NIP==NIP)
                                     join b in db.PegawaiDetail.Select() on a.NIP equals b.NIP into pegawaigrpup
                                     from b in pegawaigrpup.DefaultIfEmpty()
                                     select new pegawai
                                     {
                                         Asal = a.Asal,
                                         JabatanAkhir = a.JabatanAkhir,
                                         JenisKelamin = a.JenisKelamin,
                                         Nama = a.Nama,
                                         NIP = a.NIP,
                                         NomorKartuPegawai = a.NomorKartuPegawai,
                                         PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                         Pendidikan = a.Pendidikan,
                                         TanggalLahir = a.TanggalLahir,
                                         TempatLahir = a.TempatLahir,
                                         Detail = b
                                     };



                        var penilaians = from a in db.Penilaian.Where(o => o.TahunPeriode == periode)
                                         join n in db.PejabatPenilai.Select() on a.NIP equals n.NIP
                                         join m in result on n.NIP equals m.NIP
                                         select new penilaian
                                         {
                                             IdPenilaian = a.IdPenilaian,
                                             NIP = a.NIP,
                                             PejabatPenilaiId = a.PejabatPenilaiId,
                                             TahunPeriode = a.TahunPeriode,
                                             PejabatPenilai = m
                                         };

                        var indetail = from c in db.DetailPenilaian.Select()
                                       join b in db.KriteriaPenilaian.Select() on c.IdKriteria equals b.IdKriteria
                                       select new detailpenilaian
                                       {
                                           IdKriteria = c.IdKriteria,
                                           IdPenilaian = c.IdPenilaian,
                                           Nilai = c.Nilai,
                                           Kriteria = b
                                       };

                        var realpenilaian = from a in penilaians
                                            join d in indetail on a.IdPenilaian equals d.IdPenilaian into k
                                            from
                                             d in k.DefaultIfEmpty()
                                            select new penilaian
                                            {
                                                DaftarPenilaian = k.ToList(),
                                                IdPenilaian = a.IdPenilaian,
                                                NIP = a.NIP,
                                                PejabatPenilai = a.PejabatPenilai,
                                                PejabatPenilaiId = a.PejabatPenilaiId,
                                                TahunPeriode = a.TahunPeriode,
                                            };
                        


                        return (from a in result
                                join b in realpenilaian on a.NIP equals b.NIP
                                select new pegawai
                                {
                                    Asal = a.Asal,
                                    JabatanAkhir = a.JabatanAkhir,
                                    JenisKelamin = a.JenisKelamin,
                                    Nama = a.Nama,
                                    NIP = a.NIP,
                                    NomorKartuPegawai = a.NomorKartuPegawai,
                                    PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                    Pendidikan = a.Pendidikan,
                                    TanggalLahir = a.TanggalLahir,
                                    TempatLahir = a.TempatLahir,
                                    Detail = a.Detail,
                                    HasilPenilaian = b
                                }).ToList().FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }

        }





    }
}