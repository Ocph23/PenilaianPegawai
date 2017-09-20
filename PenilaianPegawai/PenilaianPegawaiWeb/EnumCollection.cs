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


    public enum JenisKelamin
    {
        L,P
    }

    public enum Pendidikan
    {
        SMP, SMA, S1, S2, S3
    }


    public enum Asal 
    {
         Papua, NonPapua
    }


    public enum StatusKepegawaian 
    {
         CPNS, PNS
    }

    public enum JenisKepegawaian 
    {
         PNSP, PNSD
    }

    public enum SKPejabat
    {
         Presiden, Gubernur
    }
}