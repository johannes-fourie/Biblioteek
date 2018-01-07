using Biblioteek.Types;

namespace Biblioteek.Services
{
    public interface IDatabaseAccess
    {
        BoekNommer LastBoekNommer();

        AddResult AddBoek(BoekInformation boekInformation);

        Maybe<BoekInformation> GetBoek(BoekNommer boekNommer);
    }
}