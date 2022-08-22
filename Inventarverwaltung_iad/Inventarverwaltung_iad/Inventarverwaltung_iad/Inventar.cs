using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Allgemeine Mapper-Klasse für Inventar.
    /// </summary>

    public class Inventar 
    {
        public string Hersteller { get; set; }
        public string Kaufdatum { get; set; }
        public string Garantie { get; set; }
        public string Standort { get; set; }
        public string Raum { get; set; }
        public string Position { get; set; }
        public string zuletzt_Geändert { get; set; }


    }
}
