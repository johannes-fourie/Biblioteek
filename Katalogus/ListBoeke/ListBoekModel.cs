using Biblioteek.Services;
using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Katalogus
{
    public class ListBoekModel : IListBoekModel
    {
        public IDatabaseAccess DatabaseAccess { get; set; }

        public BoekInformation GetBoek(BoekNommer boekNommer)
        {
            var boekInfo = DatabaseAccess.GetBoek(boekNommer);

        }
    }
}
