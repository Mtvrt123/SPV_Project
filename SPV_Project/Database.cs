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
            // Update user in database
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
                    //long koda = (long)reader["koda"];

                    izdelek = new Izdelek(id, ime, sestavine, alergeni, netoKolicina, nazivProizvajalca, drzavaPorekla, datumUporabe,
                        povprecnaHranilnaVrednost, energijskaVrednost, mascobe, nasiceneMascobneKisline, nenasiceneMascobneKisline, ogljikoviHidrati, sladkorji,
                        prehranskeVlaknine, beljakovine, sol);
                }

            }

            conn.Close();

            return izdelek;
        }
    }
}
