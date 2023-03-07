using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.Models
{
    public class Uporabnik
    {
        public int UporabnikID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string UporabniskoIme { get; set; }
        public string Email { get; set; }
        public string Geslo { get; set; }
    
        public Uporabnik()
        {
        }

        public Uporabnik(int uporabnikID, string ime, string priimek, string uporabniskoIme, string email, string geslo)
        {
            UporabnikID = uporabnikID;
            Ime = ime;
            Priimek = priimek;
            UporabniskoIme = uporabniskoIme;
            Email = email;
            Geslo = geslo;
        }

    }
}
