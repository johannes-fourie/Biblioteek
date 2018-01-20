using Biblioteek.Services;
using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public class AddBoekModel : IAddBoekModel
    {
        public AddBoekModel()
        { }

        public IDatabaseAccess DatabaseAccess { get; set; }

        public ActionResult AddBoek(BoekInformation boekInformation)
        {
            return DatabaseAccess.AddBoek(boekInformation);
        }

        public void Initialize()
        {
        }

        public BoekNommer NextBoekNommer()
        {
            var lastNommer = DatabaseAccess.LastBoekNommer();

            var nextNommer = new BoekNommer(lastNommer.Jaar, lastNommer.Nommer + 1);
            if (nextNommer.Jaar < CurrentJaar())
                nextNommer = new BoekNommer(CurrentJaar(), 1);

            return nextNommer;
        }

        private int CurrentJaar() => (DateTime.Now.Year % 1000) % 100;
    }
}