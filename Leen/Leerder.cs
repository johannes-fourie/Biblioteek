using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek
{
    public class LeerderData
    {
        public List<string> Naam { get; set; }

        public string Van { get; set; }

        public List<Boek> Boeke { get; set; }
    }

    public class Leening
    {
        public Boek Boek { get; set; }

        public DateTime DatumUit { get; set; }

        public DateTime? DatumIn { get; set; }

        public DateTime DatumTerugVerwag { get; set; }

        public bool BoekIsIn
        {
            get
            {
                return this.DatumIn != null;
            }
        }

        public bool BoekIsLaat
        {
            get
            {
                return this.DatumTerugVerwag.Ticks < DateTime.Now.Ticks;
            }
        }
    }

    public class Boek
    {
        public string Tietel { get; set; }

        public int Nommer { get; set; }
    }
}
