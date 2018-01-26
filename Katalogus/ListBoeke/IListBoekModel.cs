using Biblioteek.Types;
using System;
using System.Collections.Generic;

namespace Biblioteek.Katalogus
{
    public interface IListBoekModel
    {
        event EventHandler<BoekInformation> BoekAdded;

        event EventHandler<BoekInformation> BoekUpdated;

        Maybe<BoekInformation> GetBoek(BoekNommer addToList);

        List<BoekInformation> GetKatalogus();

        void Initialize();
    }
}