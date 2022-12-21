using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arabakiralama
{
    internal class KiralikBilgi
    {

        private int numara;
        private string tcNo;
        private string ad;
        private string soyad;
        private string cinsiyet;
        private string telNo;
        private string sehir;
        private Araba araba;
        private DateTime baslangicTarih;
        private DateTime bitisTarih;

        public KiralikBilgi(int numara, string tcNo, string ad, string soyad,
            string cinsiyet, string telNo, string sehir, Araba araba,
            DateTime baslangicTarih, DateTime bitisTarih)
        {
            this.numara = numara;
            this.tcNo = tcNo;
            this.ad = ad;
            this.soyad = soyad;
            this.cinsiyet = cinsiyet;
            this.telNo = telNo;
            this.sehir = sehir;
            this.araba = araba;
            this.baslangicTarih = baslangicTarih;
            this.bitisTarih = bitisTarih;
        }

        public int getNumara()
        {
            return numara;
        }

        public string getTcNo()
        {
            return tcNo;
        }

        public string getAd()
        {
            return ad;
        }

        public string getSoyad()
        {
            return soyad;
        }

        public string getCinsiyet()
        {
            return cinsiyet;
        }

        public string getTelNo()
        {
            return telNo;
        }

        public string getSehir()
        {
            return sehir;
        }

        public Araba getAraba()
        {
            return araba;
        }

        public DateTime getBaslangicTarih()
        {
            return baslangicTarih;
        }

        public DateTime getBitisTarih()
        {
            return bitisTarih;
        }
    }
}
