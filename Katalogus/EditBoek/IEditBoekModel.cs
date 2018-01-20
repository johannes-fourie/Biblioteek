using Biblioteek.Services;
using Biblioteek.Types;

namespace Biblioteek.Katalogus
{
    public interface IEditBoekModel
    {
        IDatabaseAccess DatabaseAccess { get; set; }

        Maybe<BoekInformation> GetBoek(BoekNommer boekNommer);

        void Initialize();

        void UpdateBoek(BoekInformation boekInformation);
    }
}