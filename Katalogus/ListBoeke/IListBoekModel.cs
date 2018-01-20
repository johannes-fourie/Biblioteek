using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public interface IListBoekModel
    {
        event EventHandler<BoekInformation> BoekAdded;

        event EventHandler<BoekInformation> BoekUpdated;

        Maybe<BoekInformation> GetBoek(BoekNommer addToList);

        void Initialize();
    }
}