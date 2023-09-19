using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriProjesi
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public Galeri()
        {
            SahteVeriGir();
        }
        public int GaleridekiAracSayisi
        {
            get
            {
                return this.Arabalar.Where(a => a.Durum == "Galeride").ToList().Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                return this.Arabalar.Where(t => t.Durum == "Kirada").ToList().Count;
            }
        }
        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count; // Count ile galeride ki toplam araç sayısını buluyoruz.
            }
        }
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                return this.Arabalar.Sum(a => a.KiralamaSureleri.Sum()); //arabalar listesindeki tüm arabaların toplamkiralanmasuresi'nin toplamı

            }
        }
        public int ToplamAracKiralamaAdedi
        {
            get
            {
                return this.Arabalar.Sum(a => a.KiralamaSayisi); //Sum ile kiralanan araçları kiralanma adedinin toplamına ulaşıyoruz.
            }
        }
        public float Ciro
        {
            get
            {
                return this.Arabalar.Sum(a => a.ToplamKiralamaSuresi * a.KiralamaBedeli); // Sum ile kiralanan araçların cirolarının toplamını buluyoruz.
            }
        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            //Parametreden aldığımız bilgiler ile yeni bir araba listesi oluşturarak bu bilgileri Araba classına göndererek bilgileri kaydederiz.
            //Add metodu ile eklediğimiz arabayı galeriye kaydederiz.

            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);
            this.Arabalar.Add(a);
        }
        public void SahteVeriGir()
        {
            // Oluşturduğumuz Arabaekle metodu ile manuel bilgi girerek sahteveri oluştururuz.

            ArabaEkle("34arb3434", "FIAT", 70, "Sedan");
            ArabaEkle("35arb3535", "KIA", 60, "SUV");
            ArabaEkle("34us2342", "OPEL", 50, "Hatchback");

        }

        public string DurumGetir(string plaka)
        {
            // parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // Eğer böyle bir araç varsa bulduğumuz aracın güncel durumunu döndürür eğer araç yoksa araç olmadığı için Empty döndürür.


            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();
            if (a != null)
            {
                return a.Durum;
            }
            return "ArabaYok";
        }
        public void ArabaKirala(string plaka, int sure)
        {
            //parametreden aldığımız plaka bilgisi ile araba listesinden aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // Eğer böyle bir araç var ise ve durumu galeride ise durumunu kirada olarak güncelleyip kiralanma süresine ekliyoruz.
            //

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();
            if (a != null && a.Durum == "Galeride")
            {
                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
            }
        }
        public List<Araba> ArabaListesiGetir(string durum)
        {
            // parametreden aldığımız durum veri tipinde aldığımız veri ile otogaleride araç durumlarına göre listeleme gerçekleştiriyoruz.

            List<Araba> liste = this.Arabalar;
            if (durum == "Kirada" || durum == "Galeride")
            {
                liste = this.Arabalar.Where(a => a.Durum == durum).ToList();
            }
            return liste;
        }

        public void ArabaTeslimAl(string plaka)
        {
            // parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // Eğer böyle bir araç varsa bulduğumuz aracın durumununu aracı teslim alacağımız için galeride olarak güncellenir.

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {
                if (a.Durum == "Galeride")
                {
                    throw new Exception("Zaten galeride");
                }

                a.Durum = "Galeride";
            }
            else
            {
                throw new Exception("Bu plakada bir araç yok.");
            }
        }
        public void KiralamaIptal(string plaka)
        {
            //parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // Eğer böyle bir araç var ise kiralamayı iptal edeceğimiz için durumu galeride olarak güncelleyip kiralama süresini düşüyoruz.

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {
                a.Durum = "Galeride";
                a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);
            }

        }
        public void ArabaSil(string plaka)
        {
            // parametreden aldığımız plaka bilgisi ile aradığımız aracı buluyoruz.
            // FirsOrDefault metodu çağırdığımız listede ki ilk veriyi alır.
            // remove metodu ile eğer böyle bir araç var ise ve galeride ise listeden bu aracın silinmesini sağlıyoruz.

            Araba a = this.Arabalar.Where(x => x.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null && a.Durum == "Galeride")
            {
                this.Arabalar.Remove(a);
            }
        }

    }
}
