using CommunityToolkit.Mvvm.ComponentModel;
using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.ViewModel
{
    public class ProfileViewModel : ObservableObject
    {
        public string Ime { get; private set; }
        public string Priimek { get; private set; }
        public string UporabniskoIme { get; private set; }
        public string Email { get; private set; }

        public ProfileViewModel()
        {
            GetData();
        }

        private void GetData()
        {
            Uporabnik uporabnik = App.Uporabnik;

            this.Ime = uporabnik.Ime;
            this.Priimek = uporabnik.Priimek;
            this.UporabniskoIme = uporabnik.UporabniskoIme;
            this.Email = uporabnik.Email;

        }
    }
}
