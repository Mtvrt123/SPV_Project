using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Web;

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
    }
}
