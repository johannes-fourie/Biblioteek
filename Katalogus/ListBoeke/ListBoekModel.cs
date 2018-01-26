using Biblioteek.Services;
using Biblioteek.Types;
using System;
using System.Collections.Generic;

namespace Biblioteek.Katalogus
{
    public class ListBoekModel : IListBoekModel
    {
        public event EventHandler<BoekInformation> BoekAdded;

        public event EventHandler<BoekInformation> BoekUpdated;

        public IDatabaseAccess DatabaseAccess { get; set; }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer) => this.DatabaseAccess.GetBoek(boekNommer);

        public void Initialize()
        {
            this.DatabaseAccess.BoekAdded += this.DatabaseAccess_BoekAdded;
            this.DatabaseAccess.BoekUpdated += this.DatabaseAccess_BoekUpdated;
        }

        private void DatabaseAccess_BoekAdded(object sender, BoekNommer e)
        {
            this.GetBoek(e).IfSome((b) => BoekAdded?.Invoke(this, b.Value));
        }

        private void DatabaseAccess_BoekUpdated(object sender, BoekNommer e)
        {
            this.GetBoek(e).IfSome(b => BoekUpdated?.Invoke(this, b.Value));
        }

        public List<BoekInformation> GetKatalogus()
        {
            return this.DatabaseAccess.GetKatalogus();
        }
    }
}