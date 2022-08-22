using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Mapper-Klasse für Tische.
    /// </summary>

    public class Tisch:Inventar
    {

        public string Länge { get; set; }
        public string Breite { get; set; }
        public Tisch(string Länge,string Breite) {
            this.Länge = Länge;
            this.Breite = Breite;
        }
    }
  
}
