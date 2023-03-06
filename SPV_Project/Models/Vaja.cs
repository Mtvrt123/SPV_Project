using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.Models
{
    public class Vaja
    {
        public int VadbaID { get; set; }
        public string NazivVaje { get; set; }
        public string SteviloPonovitev { get; set; }
        public string OpisVaje { get; set; }
        public string SlikaVaje { get; set; }
        public string SlikaMisice { get; set; }
        public string SportnaOprema { get; set; }
        public string TipVadbe { get; set; }
        public string ObremenjeneMisice { get; set; }
        public string TezavnostVadbe { get; set; }
        public string ObremenjenDelTelesa { get; set; }
        public string Poskodbe { get; set; }
    }
}
