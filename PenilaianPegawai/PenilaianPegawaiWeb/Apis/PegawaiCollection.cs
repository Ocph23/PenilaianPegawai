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
                var result = (from a in db.Pegawai.Where(O => O.Aktif == true)
                              join b in db.PegawaiDetail.Select() on a.IdPegawai equals b.IdPegawai into pegawaigrpup
                              from b in pegawaigrpup.DefaultIfEmpty()
                              select new pegawai
                              {
                                  Asal = a.Asal, Foto = a.Foto,
                                  JabatanAkhir = a.JabatanAkhir,
                                  JenisKelamin = a.JenisKelamin,
                                  Nama = a.Nama, NIP = a.NIP,
                                  IdPegawai = a.IdPegawai,
                                  NomorKartuPegawai = a.NomorKartuPegawai,
                                  PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                  Pendidikan = a.Pendidikan,
                                  TanggalLahir = a.TanggalLahir,
                                  TempatLahir = a.TempatLahir, Aktif = a.Aktif,
                                  Detail = b
                              }).ToList();
              var pejabats= db.PejabatPenilai.Where(O => O.Aktif == true);
                foreach(var item in pejabats)
                {
                    var r=result.Where(O => O.IdPegawai == item.IdPegawai).FirstOrDefault();
                    if (r != null)
                        result.Remove(r);
                }
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
                        p.IdPegawai = db.Pegawai.InsertAndGetLastID(p);
                        if (p.Detail != null)
                        {
                            p.Detail.IdPegawai = p.IdPegawai;
                            var saved = db.PegawaiDetail.Insert(p.Detail);
                            if (p.IdPegawai<=0|| !saved)
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
                    var detail = db.PegawaiDetail.Where(O => O.IdPegawai == p.IdPegawai).FirstOrDefault();
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
                        }, p, O => O.IdPegawai == p.IdPegawai);
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
                    O.Nama, O.NIP,
                    O.NomorKartuPegawai,
                    O.PangkatGolonganTerakhir,
                    O.Pendidikan,
                    O.TanggalLahir,
                    O.TempatLahir,O.Aktif
                }, p, O => O.IdPegawai == p.IdPegawai);
            }
        }

        public pegawai Pegawai(int IdPegawai)
        {
            using (var db = new OcphDbContext())
            {
                var result = from a in db.Pegawai.Where(O=>O.IdPegawai==IdPegawai)
                             join b in db.PegawaiDetail.Select() on a.IdPegawai equals b.IdPegawai into pegawaigrpup
                             from b in pegawaigrpup.DefaultIfEmpty()
                             select new pegawai
                             {
                                 Asal = a.Asal,Foto=a.Foto,
                                 JabatanAkhir = a.JabatanAkhir,
                                 JenisKelamin = a.JenisKelamin,
                                 Nama = a.Nama, NIP=a.NIP,
                                 IdPegawai = a.IdPegawai,
                                 NomorKartuPegawai = a.NomorKartuPegawai,
                                 PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                 Pendidikan = a.Pendidikan,
                                 TanggalLahir = a.TanggalLahir,
                                 TempatLahir = a.TempatLahir, Aktif=a.Aktif,
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
                        var result = from a in db.Pegawai.Where(O=>O.Aktif==true)
                                     join b in db.PegawaiDetail.Select() on a.IdPegawai equals b.IdPegawai into pegawaigrpup
                                     from b in pegawaigrpup.DefaultIfEmpty()
                                     select new pegawai
                                     {
                                         Asal = a.Asal,
                                         JabatanAkhir = a.JabatanAkhir,
                                         JenisKelamin = a.JenisKelamin,
                                         Nama = a.Nama, NIP=a.NIP,
                                         IdPegawai = a.IdPegawai,
                                         NomorKartuPegawai = a.NomorKartuPegawai,
                                         PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                         Pendidikan = a.Pendidikan,
                                         TanggalLahir = a.TanggalLahir,
                                         TempatLahir = a.TempatLahir,
                                         Detail = b
                                     };



                        var penilaians = from a in db.Penilaian.Where(o=>o.TahunPeriode==periode)
                                         join n in db.PejabatPenilai.Select() on a.IdPegawai equals n.IdPegawai
                                         join m in result on n.IdPegawai equals m.IdPegawai
                                         select new penilaian
                                         {
                                             IdPenilaian = a.IdPenilaian,
                                             IdPegawai = a.IdPegawai,
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
                                                IdPegawai = a.IdPegawai,
                                                PejabatPenilai = a.PejabatPenilai, 
                                                PejabatPenilaiId = a.PejabatPenilaiId,
                                                TahunPeriode = a.TahunPeriode,
                                            };
                                       ;


                        return (from a in result
                                join b in realpenilaian on a.IdPegawai equals b.IdPegawai
                                select new pegawai
                                {
                                    Asal = a.Asal, Aktif=a.Aktif,
                                    JabatanAkhir = a.JabatanAkhir,
                                    JenisKelamin = a.JenisKelamin,
                                    Nama = a.Nama, NIP=a.NIP,
                                    IdPegawai = a.IdPegawai,
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


        public pegawai PenilaianPegawai(int periode, int IdPegawai)
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
                        var result = from a in db.Pegawai.Where(O=>O.IdPegawai==IdPegawai)
                                     join b in db.PegawaiDetail.Select() on a.IdPegawai equals b.IdPegawai into pegawaigrpup
                                     from b in pegawaigrpup.DefaultIfEmpty()
                                     select new pegawai
                                     {
                                         Asal = a.Asal, Aktif=a.Aktif,
                                         JabatanAkhir = a.JabatanAkhir,
                                         JenisKelamin = a.JenisKelamin,
                                         Nama = a.Nama, NIP=a.NIP,
                                         IdPegawai = a.IdPegawai,
                                         NomorKartuPegawai = a.NomorKartuPegawai,
                                         PangkatGolonganTerakhir = a.PangkatGolonganTerakhir,
                                         Pendidikan = a.Pendidikan,
                                         TanggalLahir = a.TanggalLahir,
                                         TempatLahir = a.TempatLahir,
                                         Detail = b
                                     };



                        var penilaians = from a in db.Penilaian.Where(o => o.TahunPeriode == periode)
                                         join n in db.PejabatPenilai.Select() on a.IdPegawai equals n.IdPegawai
                                         join m in result on n.IdPegawai equals m.IdPegawai
                                         select new penilaian
                                         {
                                             IdPenilaian = a.IdPenilaian,
                                             IdPegawai = a.IdPegawai,
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
                                                IdPegawai = a.IdPegawai,
                                                PejabatPenilai = a.PejabatPenilai,
                                                PejabatPenilaiId = a.PejabatPenilaiId,
                                                TahunPeriode = a.TahunPeriode,
                                            };
                        


                        return (from a in result
                                join b in realpenilaian on a.IdPegawai equals b.IdPegawai
                                select new pegawai
                                {
                                    Asal = a.Asal, Aktif=a.Aktif, 
                                    JabatanAkhir = a.JabatanAkhir,
                                    JenisKelamin = a.JenisKelamin,
                                    Nama = a.Nama, NIP=a.NIP,
                                    IdPegawai = a.IdPegawai,
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