using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Services.DatabaseTypes
{
    [Table("Katalogus")]
    public class BoekRow
    {
        public BoekRow()
        { }

        [Key, Column(Order = 0)]
        public int Jaar { get; set; }

        [Key, Column(Order = 1)]
        public int Nommer { get; set; }

        public Genres Genre { get; set; }

        public OuderdomsGroepe OuderdomsGroep { get; set; }

        public string Skrywer { get; set; }

        public string Tietel { get; set; }

        public string Dewey { get; set; }

        public Tale Taal { get; set; }
    }
}
