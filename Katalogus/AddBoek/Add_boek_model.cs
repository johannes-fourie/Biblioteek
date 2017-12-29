using Biblioteek.Services;
using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public class Add_boek_model : IAdd_boek_model
    {
        public Add_boek_model()
        { }

        private int CurrentJaar() =>  (DateTime.Now.Year % 1000) % 100;

        public BoekNommer Next_boek_nommer()
        {
            var lastNommer = DatabaseAccess.LastBoekNommer();

            var nextNommer = new BoekNommer(lastNommer.Jaar, lastNommer.Nommer + 1);
            if (nextNommer.Jaar < CurrentJaar())
                nextNommer = new BoekNommer(CurrentJaar(), 1);

            return nextNommer;
        }

        public IDatabaseAccess DatabaseAccess { get; set; }
    }
}