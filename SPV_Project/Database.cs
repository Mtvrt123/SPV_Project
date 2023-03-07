using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project
{
    public class Database
    {
        public Uporabnik GetUser()
        {
            // Get user from database
            return new Uporabnik(1, "ImeTest", "PriimekTest", "USERNAME", "EMAIL", "GESLO");
        }

        public void UpdateUser(Uporabnik uporabnik)
        {
            // Update user in database
        }
    }
}
