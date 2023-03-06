using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.Models
{
    public class VajeNaTreningu
    {
        public int VajeNaTreninguID { get; set; }
        public int VajaVadbaID { get; set; }
        public int TreningID { get; set; }

        public virtual Uporabnik Uporabnik { get; set; }
        public virtual Trening Trening { get; set; }
    }
}
