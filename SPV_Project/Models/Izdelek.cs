using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.Models
{
    public class Izdelek
    {
        public int IzdelekID { get; set; }
        public string Ime { get; set; }
        public string Sestavine { get; set; }
        public string Alergeni { get; set; }
        public int NetoKolicina { get; set; }
        public string NazivProizvajalca { get; set; }
        public string DrzavaPorekla { get; set; }
        public DateTime DatumUporabe { get; set; }
        public decimal PovprecnaHranilnaVrednost { get; set; }
        public decimal EnergijskaVrednost { get; set; }
        public decimal Mascobe { get; set; }
        public decimal NasiceneMascobneKisline { get; set; }
        public decimal NenasiceneMascobneKisline { get; set; }
        public decimal OgljikoviHidrati { get; set; }
        public decimal Sladkorji { get; set; }
        public decimal PrehranskeVlaknine { get; set; }
        public decimal Beljakovine { get; set; }
        public decimal Sol { get; set; }
        public long Koda { get; set; }

        public Izdelek()
        {

        }

        public Izdelek(int izdelekID, string ime, string sestavine, string alergeni, int netoKolicina, string nazivProizvajalca,
            string drzavaPorekla, DateTime datumUporabe, decimal povprecnaHranilnaVrednost, decimal energijskaVrednost, decimal mascobe,
            decimal nasiceneMascobneKisline, decimal nenasiceneMascobneKisline, decimal ogljikoviHidrati, decimal sladkorji,
            decimal prehranskeVlaknine, decimal beljakovine, decimal sol)
        {
            IzdelekID = izdelekID;
            Ime = ime;
            Sestavine = sestavine;
            Alergeni = alergeni;
            NetoKolicina = netoKolicina;
            NazivProizvajalca = nazivProizvajalca;
            DrzavaPorekla = drzavaPorekla;
            DatumUporabe = datumUporabe;
            PovprecnaHranilnaVrednost = povprecnaHranilnaVrednost;
            EnergijskaVrednost = energijskaVrednost;
            Mascobe = mascobe;
            NasiceneMascobneKisline = nasiceneMascobneKisline;
            NenasiceneMascobneKisline = nenasiceneMascobneKisline;
            OgljikoviHidrati = ogljikoviHidrati;
            Sladkorji = sladkorji;
            PrehranskeVlaknine = prehranskeVlaknine;
            Beljakovine = beljakovine;
            Sol = sol;
            //Koda = koda;
        }
    }
}
