using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Inventarverwaltung_iad_asp
{
    public class Objekt
    {
        private Panel root = new Panel();
        private Label header = new Label();
        private Table grid;
        private Inventar inventar;
    
        public Objekt(string inventarnummer)
        {
      
            grid = new Table();
            grid.Font.Size = FontUnit.Medium;
            grid.Width = 550;
            grid.BorderColor = System.Drawing.Color.Black;

            SqlCon.sqlConnection.Open();
            SqlCon.command = new SqlCommand("exec dbo.getPropertiesbyInvId " + inventarnummer, SqlCon.sqlConnection);
            SqlCon.reader = SqlCon.command.ExecuteReader();
            
            while (SqlCon.reader.Read())
            {
                string anschlüsse = "";

                if (SqlCon.reader["KategorieId"].ToString() == "1")
                {
                   
                    header.Text = SqlCon.reader["Computername"].ToString();
                    header.Font.Size = FontUnit.Large;
                    header.Font.Bold = true;
                    root.Controls.Add(header);
                    inventar = new Computer(SqlCon.reader["Prozessor"].ToString(), SqlCon.reader["RAM"].ToString()+" GB",
                        SqlCon.reader["Grafik"].ToString(),
                        SqlCon.reader["HDD"].ToString()+" GB", SqlCon.reader["SSD"].ToString()+" GB");

                }
                else if (SqlCon.reader["KategorieId"].ToString() == "2")
                {

                    if (SqlCon.reader["HDMI"].ToString() == "True")
                        anschlüsse += "Hdmi,";
                    if (SqlCon.reader["DVI"].ToString() == "True")
                        anschlüsse += "Dvi,";
                    if (SqlCon.reader["VGA"].ToString() == "True")
                        anschlüsse += "Vga";

                    header.Text = "Monitor "+SqlCon.reader["MonitorId"].ToString();
                    header.Font.Size = FontUnit.Large;
                    header.Font.Bold = true;
                    root.Controls.Add(header);
                    inventar = new Monitor(anschlüsse);
                }
                else if (SqlCon.reader["KategorieId"].ToString() == "3")
                {
                    if (SqlCon.reader["HDMI"].ToString() == "True")
                        anschlüsse += "Hdmi,";
                    if (SqlCon.reader["DVI"].ToString() == "True")
                        anschlüsse += "Dvi,";
                    if (SqlCon.reader["VGA"].ToString() == "True")
                        anschlüsse += "Vga";

                    header.Text ="Beamer "+SqlCon.reader["BeamerId"].ToString();
                    header.Font.Size = FontUnit.Large;
                    header.Font.Bold = true;
                    root.Controls.Add(header);
                    inventar = new Beamer(anschlüsse);
                }
                else if (SqlCon.reader["KategorieId"].ToString() == "4")
                {
                    inventar = new Tisch(SqlCon.reader["Laenge"].ToString() + " cm", 
                        SqlCon.reader["Breite"].ToString() + " cm");
                    header.Text = "Tisch "+SqlCon.reader["TischId"].ToString();
                    header.Font.Size = FontUnit.Large;
                    header.Font.Bold = true;
                    root.Controls.Add(header);

                }
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

            for (int i = 0; i < inventar.GetType().GetProperties().Length; i++)
            {
          
                var row = new TableRow();
                var cell = new TableCell();
                cell.Text = inventar.GetType().GetProperties()[i].Name + ": "; row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = inventar.GetType().GetProperties()[i].GetValue(inventar).ToString(); row.Cells.Add(cell);
                grid.Rows.Add(row);
            }
         

            root.Controls.Add(grid);
         
        }

     
    
        public Panel getObjekt()
        {
            return root;
        }
    }
}
