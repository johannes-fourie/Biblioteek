using Biblioteek.Types;

namespace Biblioteek.Katalogus
{
    public interface IAddBoekModel
    {
        BoekNommer NextBoekNommer();

        AddResult AddBoek(BoekInformation boekInformation);

        void Initialize();
    }
}