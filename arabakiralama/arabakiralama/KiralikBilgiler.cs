using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arabakiralama
{
    internal class KiralikBilgiler
    {

        public List<KiralikBilgi> bilgiler = new List<KiralikBilgi>();

        private DBClass dbc;
        public KiralikBilgiler() {
            dbc = new DBClass();

            DataSet ds = dbc.SelectCommand("select * from kiralikbilgiler");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows){
                    bilgiler.Add(new KiralikBilgi(Convert.ToInt32(dr["numara"]), dr["tcNo"].ToString(), dr["ad"].ToString(), dr["soyad"].ToString(), dr["cinsiyet"].ToString(), dr["telNo"].ToString(), dr["sehir"].ToString(), new Araba(dr["araba_model"].ToString(), Convert.ToBoolean(dr["araba_manuel"]), dr["araba_ucret"].ToString()), DateTime.Parse(dr["baslangic_tarih"].ToString()), DateTime.Parse(dr["bitis_tarih"].ToString())));
                }
            }
        }

        public DataTable gridGetir()
        {
            DataSet ds = dbc.SelectCommand("select * from kiralikbilgiler");

            return ds.Tables[0];
        }
        public void ekle(KiralikBilgi kb)
        {
            bool sonuc = dbc.ExecuteCommand("INSERT INTO kiralikbilgiler (tcNo, ad, soyad, cinsiyet, telNo, sehir, araba_model, araba_manuel, araba_ucret, baslangic_tarih, bitis_tarih) " +
                "VALUES ('" + kb.getTcNo() + "', '" + kb.getAd() + "', '" + kb.getSoyad() + "', '" + kb.getCinsiyet() + "', '" + kb.getTelNo() + "', '" + kb.getSehir() + "', '" + kb.getAraba().getModel() + "', '" + kb.getAraba().isManuel() + "', '" + kb.getAraba().getUcret() + "', '" + kb.getBaslangicTarih() + "', '" + kb.getBitisTarih() + "')");
        
            if (sonuc) {
                bilgiler.Add(kb);
            }
        }

        public void sil(Araba araba)
        {
            bool sonuc = dbc.ExecuteCommand("DELETE FROM kiralikbilgiler WHERE araba_model = '" + araba.getModel() + "'");

            if (sonuc) {
                int index = bilgiler.FindIndex(bilgi => bilgi.getAraba().getModel() == araba.getModel());

                bilgiler.RemoveAt(index);
            }
        }
        public KiralikBilgi getBilgi(int numara)
        {
            return bilgiler.Find(bilgi => bilgi.getNumara() == numara);
        }

    }
}
