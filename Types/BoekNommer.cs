using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Types
{
    public class BoekNommer
    {
        public int Jaar { get; }

        public int Nommer { get; }

        public BoekNommer(int jaar, int nommer)
        {
            this.Jaar = jaar;
            this.Nommer = nommer;
        }
    }
}
