using Biblioteek.Services.DatabaseTypes;
using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Biblioteek.Services
{
    public class DatabaseAccess : IDatabaseAccess, IDisposable
    {
        private BiblioteekContext biblioteek;

        public DatabaseAccess()
        {
            var connectionString = ConfigurationManager.AppSettings["BiblioteekConnectionString"];
            this.biblioteek = new BiblioteekContext(connectionString);
        }

        public event EventHandler<BoekNommer> BoekAdded;

        public event EventHandler<BoekNommer> BoekUpdated;

        public ActionResult AddBoek(BoekInformation boekInfo)
        {
            ActionResult result;
            var boek = new BoekRow()
            {
                Jaar = boekInfo.BoekNommer.Jaar,
                Nommer = boekInfo.BoekNommer.Nommer,
                Genre = boekInfo.Genre,
                OuderdomsGroep = boekInfo.OuderdomsGroep,
                Skrywer = boekInfo.Skrywer.Value,
                Tietel = boekInfo.Tietel.Value,
                Dewey = boekInfo.Dewey.Number,
                Taal = boekInfo.Taal
            };

            biblioteek.Katalogus.Add(boek);
            biblioteek.SaveChanges();

            result = ActionResult.Success;
            this.BoekAdded?.Invoke(this, boekInfo.BoekNommer);

            return result;
        }

        public void Dispose()
        {
            this.biblioteek.Dispose();
        }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer)
        {
            var boekRow = this.biblioteek.Katalogus
                .Where(boekR => boekR.Jaar == boekNommer.Jaar && boekR.Nommer == boekNommer.Nommer)
                .FirstOrDefault();

            Maybe<BoekInformation> boek = boekRow is null
                ? Maybe<BoekInformation>.None()
                : new Maybe<BoekInformation>(
                    new BoekInformation(
                        boekRow.Tietel.ToTietel(),
                        boekRow.Skrywer.ToSkrywer(),
                        boekRow.Genre,
                        boekRow.OuderdomsGroep,
                        new BoekNommer(boekRow.Jaar, boekRow.Nommer),
                        boekRow.Dewey.ToDewey(),
                        boekRow.Taal));

            return boek;
        }

        public List<BoekInformation> GetKatalogus()
        {
            var boekData = this.biblioteek.Katalogus.ToList();

            var boek = boekData
                .Select(boekRow =>
                    new BoekInformation(
                        boekRow.Tietel.ToTietel(),
                        boekRow.Skrywer.ToSkrywer(),
                        boekRow.Genre,
                        boekRow.OuderdomsGroep,
                        new BoekNommer(boekRow.Jaar, boekRow.Nommer),
                        boekRow.Dewey.ToDewey(),
                        boekRow.Taal))
                .OrderByDescending(boekInfo => boekInfo.BoekNommer)
                .ToList();

            return boek;
        }

        public BoekNommer LastBoekNommer()
        {
            BoekNommer lastBoekNommer;

            var thisJaar = (DateTime.Now.Year % 1000) % 100;

            var maxJaar = this.biblioteek.Katalogus
                .Select(boekRow => boekRow.Jaar)
                .DefaultIfEmpty()
                .Max();

            if (maxJaar < thisJaar)
            {
                lastBoekNommer = new BoekNommer(jaar: (DateTime.Now.Year % 1000) % 100, nommer: 0);
            }
            else
            {
                var maxNommer = this.biblioteek.Katalogus
                    .Where(boekRow => boekRow.Jaar == maxJaar)
                    .Select(boekRow => boekRow.Nommer)
                    .DefaultIfEmpty()
                    .Max();

                lastBoekNommer = new BoekNommer(maxJaar, maxNommer);
            }

            return lastBoekNommer;
        }

        public ActionResult UpdateBoek(BoekInformation boekInformation)
        {
            var boekRow = this.biblioteek.Katalogus
                .FirstOrDefault(br => br.Jaar == boekInformation.BoekNommer.Jaar && br.Nommer == boekInformation.BoekNommer.Nommer);

            boekRow.Genre = boekInformation.Genre;
            boekRow.OuderdomsGroep = boekInformation.OuderdomsGroep;
            boekRow.Skrywer = boekInformation.Skrywer.Value;
            boekRow.Tietel = boekInformation.Tietel.Value;
            boekRow.Dewey = boekInformation.Dewey.Number;

            this.biblioteek.SaveChanges();

            this.BoekUpdated?.Invoke(this, boekInformation.BoekNommer);
            return ActionResult.Success;
        }
    }
}