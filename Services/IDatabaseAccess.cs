using Biblioteek.Types;
using System;
using System.Collections.Generic;

namespace Biblioteek.Services
{
    public interface IDatabaseAccess
    {
        event EventHandler<BoekNommer> BoekAdded;

        event EventHandler<BoekNommer> BoekUpdated;

        ActionResult AddBoek(BoekInformation boekInformation);

        Maybe<BoekInformation> GetBoek(BoekNommer boekNommer);

        BoekNommer LastBoekNommer();

        ActionResult UpdateBoek(BoekInformation boekInformation);

        List<BoekInformation> GetKatalogus();
    }
}