using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteek.Types;

namespace Biblioteek.Katalogus
{
    public interface IListBoekModel
    {
        Maybe<BoekInformation> GetBoek(BoekNommer addToList);

        event EventHandler<BoekInformation> BoekAdded;

        void Initialize();
    }
}
