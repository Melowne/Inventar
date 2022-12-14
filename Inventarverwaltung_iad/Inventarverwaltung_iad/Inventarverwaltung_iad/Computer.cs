using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;

namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Mapper-Klasse für Computer.
    /// </summary>

    public class Computer : Inventar
    {
        public string Prozessor { get; set; }
        public string RAM { get; set; }
        public string Grafik { get; set; }
        public string HDD { get; set; }
        public string SSD { get; set; }

        public Computer(string Prozessor, string RAM, string Grafik, string HDD, string SSD)
        {
            this.Prozessor = Prozessor;
            this.RAM = RAM;
            this.Grafik = Grafik;
            this.HDD = HDD;
            this.SSD = SSD;
        }

    }

}
