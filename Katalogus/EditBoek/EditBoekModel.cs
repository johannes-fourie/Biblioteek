using Biblioteek.Services;
using Biblioteek.Types;

namespace Biblioteek.Katalogus
{
    public class EditBoekModel : IEditBoekModel
    {
        public IDatabaseAccess DatabaseAccess { get; set; }

        public Maybe<BoekInformation> GetBoek(BoekNommer boekNommer) => this.DatabaseAccess.GetBoek(boekNommer);

        public void Initialize()
        {
        }

        public void UpdateBoek(BoekInformation boekInformation) => this.DatabaseAccess.UpdateBoek(boekInformation);
    }
}