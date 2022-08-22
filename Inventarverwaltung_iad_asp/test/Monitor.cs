using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Inventarverwaltung_iad_asp
{
    internal class Monitor:Inventar
    {
   public string Anschlüsse { get; set; }
        public Monitor(string Anschlüsse)
        {
            this.Anschlüsse = Anschlüsse;
        }
    }

}
