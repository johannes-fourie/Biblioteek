using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Services
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public DatabaseAccess()
        {
        }

        public BoekNommer LastBoekNommer()
        {
            return new BoekNommer(
                jaar: (DateTime.Now.Year % 1000) % 100,
                nommer: 10);
        }
    }
}
