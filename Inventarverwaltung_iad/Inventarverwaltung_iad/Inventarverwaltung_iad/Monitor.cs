using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Mapper-Klasse für Monitore.
    /// </summary>

    public class Monitor:Inventar
    {
   public string Anschlüsse { get; set; }
        public Monitor(string Anschlüsse)
        {
            this.Anschlüsse = Anschlüsse;
        }
    }

}
