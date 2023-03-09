using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Web;
using System.Numerics;
using System.Collections.ObjectModel;
using Google.Protobuf.Collections;
using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml.Controls;

namespace SPV_Project
{
    public class Database
    {
        private MySqlConnection conn;

        public Database() 
        {
            string connStr = "server=localhost;user=root;database=mydb;port=3306;password=";
            conn = new MySqlConnection(connStr);
        }

        public Uporabnik GetUser()
        {

            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from uporabnik where uporabnik_ID=@id", conn);
            command.Parameters.AddWithValue("@id", "1");

            int result = command.ExecuteNonQuery();

            Uporabnik uporabnik = null;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int id = (int)reader["uporabnik_ID"];
                    string email = (string)reader["email"];
                    string password = (string)reader["geslo"];

                    uporabnik = new Uporabnik(id, "IME", "PRIIMEK", "USERNAME", email, password);
                }

            }

            conn.Close();

            return uporabnik;
        }

        public void UpdateUser(Uporabnik uporabnik)
        {
            
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE uporabnik SET email=@email, geslo=@geslo WHERE uporabnik_ID=@id", conn);
            command.Parameters.AddWithValue("@id", uporabnik.UporabnikID);
            command.Parameters.AddWithValue("@email", uporabnik.Email);
            command.Parameters.AddWithValue("@geslo", uporabnik.Geslo);

            int result = command.ExecuteNonQuery();

            conn.Close();
        }




        public Izdelek GetIzdelek()
        {

            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from izdelek where izdelek_ID=@id", conn);
            command.Parameters.AddWithValue("@id", "1");

            int result = command.ExecuteNonQuery();

            Izdelek izdelek = null;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int id = (int)reader["izdelek_ID"];
                    string ime = (string)reader["ime"];
                    string sestavine = (string)reader["sestavine"];
                    string alergeni = (string)reader["alergeni"];
                    int netoKolicina = (int)reader["neto_kolicina"];
                    string nazivProizvajalca = (string)reader["naziv_proizvajalca"];
                    string drzavaPorekla = (string)reader["drzava_porekla"];
                    DateTime datumUporabe = (DateTime)reader["datum_uporabe"];
                    decimal povprecnaHranilnaVrednost = (decimal)reader["povprecna_hranilna_vrednost"];
                    decimal energijskaVrednost = (decimal)reader["energijska_vrednost"];
                    decimal mascobe = (decimal)reader["mascobe"];
                    decimal nasiceneMascobneKisline = (decimal)reader["nasicene_mascobne_kisline"];
                    decimal nenasiceneMascobneKisline = (decimal)reader["nenasicene_mascobne_kisline"];
                    decimal ogljikoviHidrati = (decimal)reader["ogljikovi_hidrati"];
                    decimal sladkorji = (decimal)reader["sladkorji"];
                    decimal prehranskeVlaknine = (decimal)reader["prehranske_vlaknine"];
                    decimal beljakovine = (decimal)reader["beljakovine"];
                    decimal sol = (decimal)reader["sol"];
                    string koda = reader["koda"].ToString();

                    izdelek = new Izdelek(id, ime, sestavine, alergeni, netoKolicina, nazivProizvajalca, drzavaPorekla, datumUporabe,
                        povprecnaHranilnaVrednost, energijskaVrednost, mascobe, nasiceneMascobneKisline, nenasiceneMascobneKisline, ogljikoviHidrati, sladkorji,
                        prehranskeVlaknine, beljakovine, sol, koda);
                }

            }

            conn.Close();

            return izdelek;
        }

        internal ObservableCollection<Vaja> GetExercises()
        {
            ObservableCollection<Vaja> vaje = new ObservableCollection<Vaja>();
            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from vaja", conn);

            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Vaja vaja = new Vaja();
                vaja.VadbaID = Convert.ToInt32(dr["vaja_ID"]);
                vaja.NazivVaje = dr["naziv_vaje"].ToString();

                vaja.SteviloPonovitev = dr["stevilo_ponovitev"].ToString();
                vaja.OpisVaje = dr["opis_vaje"].ToString();

                switch(dr["naziv_vaje"].ToString())
                {
                    case "Bench Press":
                        vaja.SlikaVaje = "Resources/Exercises/bench_press.gif";
                        break;
                    case "Pullups":
                        vaja.SlikaVaje = "Resources/Exercises/pullup.gif";
                        break;
                    case "Pushups":
                        vaja.SlikaVaje = "Resources/Exercises/pushups.gif";
                        break;
                }

                vaja.SlikaMisice = dr["slika_misice"].ToString();
                vaja.SportnaOprema = dr["sportna_oprema"].ToString();
                vaja.TipVadbe = dr["tip_vaje"].ToString();
                vaja.ObremenjeneMisice = dr["obremenjene_misice"].ToString();
                vaja.TezavnostVadbe = dr["tezavnost_vaje"].ToString();
                vaja.ObremenjenDelTelesa = dr["obremenjen_del_telesa"].ToString();
                vaja.Poskodbe = dr["poskodbe"].ToString();

                vaje.Add(vaja);
            }
            
            conn.Close();

            return vaje;

        }
    }
}
