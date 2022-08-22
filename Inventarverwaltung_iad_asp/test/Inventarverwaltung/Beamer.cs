using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Inventarverwaltung_iad_asp
{
    internal class Beamer : Inventar
    {
                public string Anschlüsse { get; set; }
        public Beamer(string Anschlüsse)
        {
            this.Anschlüsse = Anschlüsse;
        }
    }

}


