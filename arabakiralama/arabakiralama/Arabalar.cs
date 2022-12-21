using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arabakiralama
{
    internal class Arabalar
    {

        public List<Araba> arabalar = new List<Araba>();

        public Arabalar()
        {
            ekle(new Araba("Renault Yeni Clio", true, "2.89 ₺"));
            ekle(new Araba("Hyundai i20", false, "3.39 ₺"));
            ekle(new Araba("Renault Megane", false, "3.99 ₺"));
            ekle(new Araba("Renault Zoe", false, "2.50 ₺"));
        }

        public void ekle(Araba araba)
        {
            arabalar.Add(araba);
        }

        public void sil(Araba araba)
        {
            arabalar.Remove(araba); 
        }

        public Araba getAraba(String model)
        {
            return arabalar.Find(araba => araba.getModel() == model);
        }

    }
}
