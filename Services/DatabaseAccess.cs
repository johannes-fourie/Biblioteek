using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteek.Services
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public event EventHandler<BoekNommer> BoekAdded;

        public DatabaseAccess()
        { }

        private List<BoekInformation> boeke = new List<BoekInformation>();
        private BoekNommer lastAddedBoekNommer;

        public BoekNommer LastBoekNommer()
        {
            return boeke.LastOrDefault()?.BoekNommer
                ?? new BoekNommer(
                    jaar: (DateTime.Now.Year % 1000) % 100,
                    nommer: 0);
        }

        public AddResult AddBoek(BoekInformation boekInfo)
        {
            AddResult result;
            if (this.boeke.Any(b => b.BoekNommer.Equals(boekInfo.BoekNommer)))
                result = AddResult.AddFail;
            else
            {
                this.boeke.Add(boekInfo);
                result = AddResult.AddSuccess;
                this.BoekAdded?.Invoke(this, boekInfo.BoekNommer);
            }

            return result;
        }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer)
        {
            return this.boeke.FirstOrDefault(b => b.BoekNommer == boekNommer) ?? default;
        }
    }
}