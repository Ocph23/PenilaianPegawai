using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PenilaianPegawaiWeb
{
    public class EnumCollection
    {
    }

    public enum Kepercayaan
    {
        Islam, Protestan, Khatolik, Hindu, Budha, Konghuchu
    }

    public enum Kelamin
    {
        Pria, Wanita
    }

    public enum Hubungan
    {
        KepalaKeluarga,Istri,Anak,Ibu,Bapak,Famili
    }

    public enum StatusPerkawinan
    {
        Kawin,Belum
    }

    public enum Kewarganegaraan
    {
        WNI, WNA
    }


    public enum Pendidikan
    {
        SD, SMP, SMA, S1, S2, S3
    }

    public enum LevelStruktur
    {
        RT, RW, Lurah
    }
    public enum JenisJabatan
    {
        Ketua, Sekertaris
    }
}