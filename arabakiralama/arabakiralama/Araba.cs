using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arabakiralama
{
    internal class Araba
    {

        private string model;
        private bool manuel;
        private string ucret;

        public Araba(string model, bool manuel, string ucret)
        {
            this.model = model;
            this.manuel = manuel;
            this.ucret = ucret;
        }

        public string getModel()
        {
            return model;
        }

        public bool isManuel()
        {
            return manuel;
        }

        public string getUcret()
        {
            return ucret;
        }
    }
}
