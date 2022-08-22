using System.Data.SqlClient;
using Xamarin.Forms;
namespace Inventarverwaltung_iad
{
    /// <summary>
    /// Dise Klasse wird dafür verwendet ein StackPane mit Eigenschaften 
    /// eines einzelnen Inventargegenstandes zurückzugeben.
    /// </summary>
    public class Objekt
    {
        private StackLayout root = new StackLayout();
        private Frame header = new Frame();
        private Grid grid = new Grid();
        private Inventar inventar;

        public Objekt(string inventarnummer)
        {
            root.Orientation = StackOrientation.Vertical;
            SqlCon.sqlConnection.Open();
            SqlCon.command = new SqlCommand("exec dbo.getPropertiesbyInvId " + inventarnummer, SqlCon.sqlConnection);
            SqlCon.reader = SqlCon.command.ExecuteReader();
            // Beim initialisieren wird über die Prozedur dbo.getPropertiesbyInvId über die Inventarnummer geprüft,
            // welche Kategorie der Inventargegenstand besitzt.
            /// <summary>
            /// Beim initialisieren wird über die Prozedur dbo.getPropertiesbyInvId über
            /// die Inventarnummer geprüft, welche Kategorie der Inventargegenstand besitzt.
            /// Anschliessend werden die relevanten Eigenschaften für das Kategorieobjekt 
            /// dem Konstruktor übergeben und es wird ein Objekt davon erstellt.
            /// </summary>
            while (SqlCon.reader.Read())
            {
                string anschlüsse = "";

                if (SqlCon.reader["KategorieId"].ToString() == "1")
                {
                    header.BackgroundColor = Color.FromHex("#fe0000"); header.Padding = 16; header.CornerRadius = 0;
                    header.Content = new Label
                    {
                        Text = SqlCon.reader["Computername"].ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.White,
                        FontSize = 22
                    };

                    root.Children.Add(header);
                    inventar = new Computer(SqlCon.reader["Prozessor"].ToString(), SqlCon.reader["RAM"].ToString() + " GB", 
                    SqlCon.reader["Grafik"].ToString(), SqlCon.reader["HDD"].ToString() + " GB", SqlCon.reader["SSD"].ToString() + " GB");

                }
                else if (SqlCon.reader["KategorieId"].ToString() == "2")
                {

                    header.BackgroundColor = Color.FromHex("#fe0000"); header.Padding = 16; header.CornerRadius = 0;
                    header.Content = new Label
                    {
                        Text = "Monitor " + SqlCon.reader["MonitorId"].ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.White,
                        FontSize = 22
                    };
                    if (SqlCon.reader["HDMI"].ToString() == "True")
                        anschlüsse += "Hdmi,";
                    if (SqlCon.reader["DVI"].ToString() == "True")
                        anschlüsse += "Dvi,";
                    if (SqlCon.reader["VGA"].ToString() == "True")
                        anschlüsse += "Vga";

                    root.Children.Add(header);
                    inventar = new Monitor(anschlüsse);
                }
                else if (SqlCon.reader["KategorieId"].ToString() == "3")
                {
                    header.BackgroundColor = Color.FromHex("#fe0000"); header.Padding = 16; header.CornerRadius = 0;
                    header.Content = new Label
                    {
                        Text = "Beamer " + SqlCon.reader["BeamerId"].ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.White,
                        FontSize = 22
                    };
                    if (SqlCon.reader["HDMI"].ToString() == "True")
                        anschlüsse += "Hdmi,";
                    if (SqlCon.reader["DVI"].ToString() == "True")
                        anschlüsse += "Dvi,";
                    if (SqlCon.reader["VGA"].ToString() == "True")
                        anschlüsse += "Vga";

                    root.Children.Add(header);
                    inventar = new Beamer(anschlüsse);
                }
                else if (SqlCon.reader["KategorieId"].ToString() == "4")
                {
                    header.BackgroundColor = Color.FromHex("#fe0000"); header.Padding = 16; header.CornerRadius = 0;
                    header.Content = new Label
                    {
                        Text = "Tisch " + SqlCon.reader["TischId"].ToString(),
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.White,
                        FontSize = 22
                    };
                    inventar = new Tisch(SqlCon.reader["Laenge"].ToString() + " cm", SqlCon.reader["Breite"].ToString() + " cm");
                    root.Children.Add(header);
                 }
                /// <summary>
                /// Im Anschluss werden die allgemeinen Eigenschaften hinzugefügt
                /// </summary>
                inventar.Hersteller = SqlCon.reader["Herstellername"].ToString();
                inventar.Kaufdatum = SqlCon.reader["Kaufdatum"].ToString().Substring(0, 10);
                inventar.Garantie = SqlCon.reader["Garantie"].ToString();
                inventar.Standort = SqlCon.reader["Standortname"].ToString();
                inventar.Raum = SqlCon.reader["Raum"].ToString();
                inventar.Position = SqlCon.reader["Position"].ToString();
                inventar.zuletzt_Geändert = SqlCon.reader["Admin"].ToString();
             }
            SqlCon.reader.Close();
            SqlCon.sqlConnection.Close();
            /// Danach wird durch das eben erstellte Objekt iteriert und es werden alle 
            /// benötigten Eigenschaften in einer grid-Tabelle gespeichert und dem Root-Element hinzugefügt.
            for (int i = 0; i < inventar.GetType().GetProperties().Length; i++)
            {
                grid.Children.Add(new Label
                {
                    Text = inventar.GetType().GetProperties()[i].Name + ": ",
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 16,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, i);
                grid.Children.Add(new Label
                {
                    Text = inventar.GetType().GetProperties()[i].GetValue(inventar).ToString(),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 16,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, i);
            }
            root.Children.Add(grid);
        }
        //Gibt das Root-Element mit der eben erstellten grid-Tabelle zurück.
        public StackLayout getObjekt()
        {
            return root;
        }
    }
}
