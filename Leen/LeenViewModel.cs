using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek
{
    public class LeenViewModel
    {
        public List<string> Leerder { get; } = new List<string>
        {
            "Van 1, Naam 2",
            "Van 2, Naam 3",
            "Van 3, Naam 4",
            "Van 4, Naam 5",
            "Van 5, Naam 6",
            "Van 6, Naam 7",
            "Van 7, Naam 8",
            "Van 8, Naam 9",
            "Van 9, Naam 10",
            "Van 10, Naam 11",
            "Van 11, Naam 12",
            "Van 12, Naam 13",
            "Van 13, Naam 14",
            "Van 14, Naam 15",
            "Van 15, Naam 16",
            "Van 16, Naam 17",
            "Van 17, Naam 18",
            "Van 18, Naam 19",
            "Van 19, Naam 20",
            "Van 20, Naam 21",
            "Van 21, Naam 22",
            "Van 22, Naam 23",
            "Van 23, Naam 24",
            "Van 24, Naam 25",
            "Van 25, Naam 26",
            "Van 26, Naam 27",
            "Van 27, Naam 28",
            "Van 28, Naam 29",
            "Van 29, Naam 30",
            "Van 30, Naam 31",
            "Van 31, Naam 32",
            "Van 32, Naam 33",
            "Van 33, Naam 34",
            "Van 34, Naam 35",
            "Van 35, Naam 36",
            "Van 36, Naam 37",
            "Van 37, Naam 38",
            "Van 38, Naam 39",
            "Van 39, Naam 40",
            "Van 40, Naam 41",
            "Van 41, Naam 42",
            "Van 42, Naam 43",
            "Van 43, Naam 44",
            "Van 44, Naam 45",
            "Van 45, Naam 46",
            "Van 46, Naam 47",
            "Van 47, Naam 48",
            "Van 48, Naam 49",
            "Van 49, Naam 50",
            "Van 50, Naam 51",
            "Van 51, Naam 52",
            "Van 52, Naam 53",
            "Van 53, Naam 54",
            "Van 54, Naam 55",
            "Van 55, Naam 56",
            "Van 56, Naam 57",
            "Van 57, Naam 58"
        };

        public List<Boek> Boeke = new List<Boek>()
        {
            new Boek() {Tietel="Boek 1", Nommer=124},
            new Boek() {Tietel="Boek 2", Nommer=125},
            new Boek() {Tietel="Boek 3", Nommer=126},
            new Boek() {Tietel="Boek 4", Nommer=127},
            new Boek() {Tietel="Boek 5", Nommer=128},
            new Boek() {Tietel="Boek 6", Nommer=129},
            new Boek() {Tietel="Boek 7", Nommer=130},
            new Boek() {Tietel="Boek 8", Nommer=131},
            new Boek() {Tietel="Boek 9", Nommer=132},
            new Boek() {Tietel="Boek 10", Nommer=133},
            new Boek() {Tietel="Boek 11", Nommer=134},
            new Boek() {Tietel="Boek 12", Nommer=135},
            new Boek() {Tietel="Boek 13", Nommer=136},
            new Boek() {Tietel="Boek 14", Nommer=137},
            new Boek() {Tietel="Boek 15", Nommer=138},
            new Boek() {Tietel="Boek 16", Nommer=139},
            new Boek() {Tietel="Boek 17", Nommer=140},
            new Boek() {Tietel="Boek 18", Nommer=141},
            new Boek() {Tietel="Boek 19", Nommer=142},
            new Boek() {Tietel="Boek 20", Nommer=143},
            new Boek() {Tietel="Boek 21", Nommer=144},
            new Boek() {Tietel="Boek 22", Nommer=145},
            new Boek() {Tietel="Boek 23", Nommer=146},
            new Boek() {Tietel="Boek 24", Nommer=147},
            new Boek() {Tietel="Boek 25", Nommer=148},
            new Boek() {Tietel="Boek 26", Nommer=149},
            new Boek() {Tietel="Boek 27", Nommer=150},
            new Boek() {Tietel="Boek 28", Nommer=151},
            new Boek() {Tietel="Boek 29", Nommer=152},
            new Boek() {Tietel="Boek 30", Nommer=153},
            new Boek() {Tietel="Boek 31", Nommer=154},
            new Boek() {Tietel="Boek 32", Nommer=155},
            new Boek() {Tietel="Boek 33", Nommer=156},
            new Boek() {Tietel="Boek 34", Nommer=157},
            new Boek() {Tietel="Boek 35", Nommer=158},
            new Boek() {Tietel="Boek 36", Nommer=159},
            new Boek() {Tietel="Boek 37", Nommer=160},
            new Boek() {Tietel="Boek 38", Nommer=161},
            new Boek() {Tietel="Boek 39", Nommer=162},
            new Boek() {Tietel="Boek 40", Nommer=163},
            new Boek() {Tietel="Boek 41", Nommer=164},
            new Boek() {Tietel="Boek 42", Nommer=165},
            new Boek() {Tietel="Boek 43", Nommer=166},
            new Boek() {Tietel="Boek 44", Nommer=167},
            new Boek() {Tietel="Boek 45", Nommer=168},
            new Boek() {Tietel="Boek 46", Nommer=169},
            new Boek() {Tietel="Boek 47", Nommer=170},
            new Boek() {Tietel="Boek 48", Nommer=171},
            new Boek() {Tietel="Boek 49", Nommer=172},
            new Boek() {Tietel="Boek 50", Nommer=173},
            new Boek() {Tietel="Boek 51", Nommer=174},
            new Boek() {Tietel="Boek 52", Nommer=175},
            new Boek() {Tietel="Boek 53", Nommer=176},
            new Boek() {Tietel="Boek 54", Nommer=177},
            new Boek() {Tietel="Boek 55", Nommer=178},
            new Boek() {Tietel="Boek 56", Nommer=179},
            new Boek() {Tietel="Boek 57", Nommer=180}
        };

        public List<Leening> Leening { get; set; } = new List<Leening>()
        {
            new Biblioteek.Leening()
            {
                Boek = new Boek() { Nommer = 12345, Tietel = "Boek een" },
                DatumUit = DateTime.Now,
                DatumIn = DateTime.Now,
                DatumTerugVerwag  = DateTime.Now.AddDays(14)
            },

            new Biblioteek.Leening()
            {
                Boek = new Boek() { Nommer = 45789, Tietel = "Boek twee" },
                DatumUit = DateTime.Now,
                DatumIn = null,
                DatumTerugVerwag  = DateTime.Now.AddDays(14)
            },

            new Biblioteek.Leening()
            {
                Boek = new Boek() { Nommer = 012364, Tietel = "Boek Drie" },
                DatumUit = DateTime.Now,
                DatumTerugVerwag  = DateTime.Now.AddDays(-14)
            }
        };
    }
}
