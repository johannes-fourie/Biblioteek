using Biblioteek.Services;
using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public class ListBoekModel : IListBoekModel
    {
        private IDatabaseAccess databaseAccess;

        public event EventHandler<BoekInformation> BoekAdded;

        public IDatabaseAccess DatabaseAccess { get; set; }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer) => this.DatabaseAccess.GetBoek(boekNommer);

        public void Initialize()
        {
            this.DatabaseAccess.BoekAdded += this.DatabaseAccess_BoekAdded;
        }

        private void DatabaseAccess_BoekAdded(object sender, BoekNommer e)
        {
            this.GetBoek(e).IfSome((b) => BoekAdded?.Invoke(this, b.Value));
        }
    }
}