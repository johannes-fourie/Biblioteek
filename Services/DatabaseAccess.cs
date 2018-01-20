using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteek.Services
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private List<BoekInformation> boeke = new List<BoekInformation>();

        public DatabaseAccess()
        { }

        public event EventHandler<BoekNommer> BoekAdded;

        public event EventHandler<BoekNommer> BoekUpdated;

        public ActionResult AddBoek(BoekInformation boekInfo)
        {
            ActionResult result;
            if (this.boeke.Any(b => b.BoekNommer.Equals(boekInfo.BoekNommer)))
                result = ActionResult.Fail;
            else
            {
                this.boeke.Add(boekInfo);
                result = ActionResult.Success;
                this.BoekAdded?.Invoke(this, boekInfo.BoekNommer);
            }

            return result;
        }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer)
        {
            return this.boeke.FirstOrDefault(b => b.BoekNommer == boekNommer) ?? default;
        }

        public BoekNommer LastBoekNommer()
        {
            return boeke.LastOrDefault()?.BoekNommer
                ?? new BoekNommer(
                    jaar: (DateTime.Now.Year % 1000) % 100,
                    nommer: 0);
        }

        public ActionResult UpdateBoek(BoekInformation boekInformation)
        {
            this.boeke.Remove(this.boeke.First(b => b.BoekNommer == boekInformation.BoekNommer));
            this.boeke.Insert(0, boekInformation);
            this.BoekUpdated?.Invoke(this, boekInformation.BoekNommer);
            return ActionResult.Success;
        }
    }
}