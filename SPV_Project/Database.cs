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
using System.Security.Cryptography;
using Microsoft.Maui.ApplicationModel.Communication;

namespace SPV_Project
{
    public class Database
    {
        private MySqlConnection conn;

        private Uporabnik uporabnik;

        public Database() 
        {
            string connStr = "server=localhost;user=root;database=mydb;port=3306;password=";
            conn = new MySqlConnection(connStr);
        }

        public Uporabnik GetUser()
        {
            return this.uporabnik;
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

        public bool Registracija(string mail, string pass)
        {

            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO uporabnik (uporabnik_ID, email, geslo) VALUES (DEFAULT, @email,@geslo);", conn);
     
            command.Parameters.AddWithValue("@email", mail);
            command.Parameters.AddWithValue("@geslo", Convert.ToHexString(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(pass)))).ToString().ToLower();

            int result = command.ExecuteNonQuery();

            conn.Close();
            return true;
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


        public List<string> GetVseSportneOpreme()
        {
            var sportnaOpremaUnikatneVrednostiList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT sportna_oprema FROM vaja";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sportnaOpremaUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return sportnaOpremaUnikatneVrednostiList;
        }


        public List<string> GetVseTipeVadbe()
        {
            var tipVadbeUnikatneVrednostiList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT tip_vaje FROM vaja";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tipVadbeUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tipVadbeUnikatneVrednostiList;
        }


        public List<string> GetVseObremenjeneDeleTelesa()
        {
            var obremenjeneMisiceUnikatneVrednostiList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT obremenjene_misice FROM vaja";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obremenjeneMisiceUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return obremenjeneMisiceUnikatneVrednostiList;
        }



        public List<string> GetVseTezavnostiVaje()
        {
            var tezavnostVadbeUnikatneVrednostiList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT tezavnost_vaje FROM vaja";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tezavnostVadbeUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tezavnostVadbeUnikatneVrednostiList;
        }


        public List<string> GetVsePoskodbe()
        {
            var poskodbeUnikatneVrednostiList = new List<string>();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT poskodbe FROM vaja";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            poskodbeUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return poskodbeUnikatneVrednostiList;
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

        public bool Login(string username, string password)
        {
            Uporabnik uporabnik = null;

            // !!! BACKDOOR FOR TESTING AND PEOPLE WHO DONT HAVE DB SETUP !!!
            if (username == null && password == null)
            {
                uporabnik = new Uporabnik(1, "IME", "PRIIMEK", "USERNAME", "EMAIL", "PASSWORD");
            }
            else
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select * from uporabnik where email=@email and geslo=@geslo", conn);
                command.Parameters.AddWithValue("@email", username);
                command.Parameters.AddWithValue("@geslo", Convert.ToHexString(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))).ToString().ToLower();

                int result = command.ExecuteNonQuery();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = (int)reader["uporabnik_ID"];
                        string email = (string)reader["email"];
                        string pass = (string)reader["geslo"];

                        uporabnik = new Uporabnik(id, "IME", "PRIIMEK", "USERNAME", email, pass);
                    }

                }

                conn.Close();
            }


            if (uporabnik != null)
            {
                this.uporabnik = uporabnik;
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public bool CheckIfEmailExists(string user)
        {
            Uporabnik uporabnik = null;


                conn.Open();
                MySqlCommand command = new MySqlCommand("Select * from uporabnik where email=@email", conn);
                command.Parameters.AddWithValue("@email", user);
               

                int result = command.ExecuteNonQuery();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = (int)reader["uporabnik_ID"];
                        string email = (string)reader["email"];
                        string pass = (string)reader["geslo"];

                        uporabnik = new Uporabnik(id, "IME", "PRIIMEK", "USERNAME", email, pass);
                    }

                }

                conn.Close();
            


            if (uporabnik != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<string> PolniVaje(string a,string b,string c,string d)
        {
            var poskodbeUnikatneVrednostiList = new List<string>();



            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT naziv_vaje FROM vaja WHERE sportna_oprema="+"'"+a+"'"+" and obremenjene_misice="+"'"+b+"'"+" and tezavnost_vaje="+"'"+c+"'"+" and poskodbe="+"'"+d+"'";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            poskodbeUnikatneVrednostiList.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return poskodbeUnikatneVrednostiList;
        }

        public List<string> GetOpravljeneVaje(string a, string b, string c, string d)  //spremenis na uporabnika in iz nove tabele(če jo bo kdo naredil) izpises pretekle vaje.
        {
            var lista_vaj_uporabnika = new List<string>();



            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=mydb;port=3306;password="))
            {
                connection.Open();
                string query = "SELECT DISTINCT naziv_vaje FROM vaja WHERE sportna_oprema=" + "'" + a + "'" + " and obremenjene_misice=" + "'" + b + "'" + " and tezavnost_vaje=" + "'" + c + "'" + " and poskodbe=" + "'" + d + "'";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista_vaj_uporabnika.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return lista_vaj_uporabnika;
        }


    }
}
