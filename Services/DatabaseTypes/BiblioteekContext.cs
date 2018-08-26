using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Services.DatabaseTypes
{
    public class BiblioteekContext : DbContext
    {
        public BiblioteekContext()
        {}

        public BiblioteekContext(string connectionString)
           : base(connectionString)
        { }

        public DbSet<BoekRow> Katalogus { get; set; }
    }
}

