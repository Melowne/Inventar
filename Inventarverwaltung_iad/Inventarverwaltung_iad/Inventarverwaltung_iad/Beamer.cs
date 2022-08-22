using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Mapper-Klasse für Beamer.
    /// </summary>

    public class Beamer : Inventar
    {
                public string Anschlüsse { get; set; }
        public Beamer(string Anschlüsse)
        {
            this.Anschlüsse = Anschlüsse;
        }
    }

}


