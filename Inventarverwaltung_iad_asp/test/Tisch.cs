using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;


namespace Inventarverwaltung_iad_asp
{
    internal class Tisch:Inventar
    {

        public string Länge { get; set; }
        public string Breite { get; set; }
        public Tisch(string Länge,string Breite) {
            this.Länge = Länge;
            this.Breite = Breite;
        }
    }
  
}
