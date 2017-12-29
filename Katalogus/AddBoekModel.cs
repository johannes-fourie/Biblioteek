using Biblioteek.Services;
using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public class AddBoekModel : IAddBoekModel
    {
        public AddBoekModel()
        { }

        private int CurrentJaar() =>  (DateTime.Now.Year % 1000) % 100;

        public BoekNommer NextBoekNommer()
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