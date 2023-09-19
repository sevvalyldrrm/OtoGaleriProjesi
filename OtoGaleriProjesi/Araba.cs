using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriProjesi
{
    class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();
        public int KiralamaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }

        public int ToplamKiralamaSuresi
        {
            get
            {
                return this.KiralamaSureleri.Sum();
            }
        }

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            //Araba metodunda parametreli constructor oluşturarak parametreden aldığımız verileri listedeki arabanın bilgilerine ekliyoruz.

            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = "Galeride";
        }




    }


}
