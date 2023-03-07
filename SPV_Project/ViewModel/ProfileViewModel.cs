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
        public Uporabnik Uporabnik { get; private set; }

        public ProfileViewModel()
        {
            this.Uporabnik = App.Database.GetUser();
        }

        public void UpdateData(string ime, string priimek, string uporabniskoIme, string email)
        {
            this.Uporabnik.Ime = ime;
            this.Uporabnik.Priimek = priimek;
            this.Uporabnik.UporabniskoIme = uporabniskoIme;
            this.Uporabnik.Email = email;

            App.Database.UpdateUser(Uporabnik);
        }
        


    }
}
