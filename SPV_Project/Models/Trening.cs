using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.Models
{
    public class Trening
    {
        public int TreningID { get; set; }
        public DateTime DatumTreninga { get; set; }
        public string TrajanjeTreninga { get; set; }
        public int UporabnikId { get; set; }

        public virtual Uporabnik Uporabnik { get; set; }
    }
}
