using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Inventarverwaltung_iad_asp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Button infobutton;
        private static string inventarnummer;

        private string[] eigenschaften = new string[] { "Name", "Position", "Raum", "Infos" };
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //SqlCon.checkLogin("Meyer", "****");
                try
                {

                    //kategorien
                    SqlCon.sqlConnection.Open();
                    SqlCon.command = new SqlCommand("exec dbo.getObjekte", SqlCon.sqlConnection);
                    SqlCon.reader = SqlCon.command.ExecuteReader();
                    while (SqlCon.reader.Read())
                    {
                        objekt.Items.Add(SqlCon.reader["Bezeichnung"].ToString());
                    }
                    SqlCon.reader.Close();
                    //orte
                    SqlCon.command = new SqlCommand("exec dbo.getOrte", SqlCon.sqlConnection);
                    SqlCon.reader = SqlCon.command.ExecuteReader();
                    while (SqlCon.reader.Read())
                    {
                        orte.Items.Add(SqlCon.reader["Standortname"].ToString());
                    }
                    SqlCon.reader.Close();
                    SqlCon.sqlConnection.Close();

                }
                catch (Exception)
                {
                    SqlCon.sqlConnection.Close();
                    Response.Redirect("~/Login.aspx", true);
                }
            }



            try
            {
                //content grid erstellen

                grid.Font.Size = FontUnit.Medium;
                grid.Width = 550;
                grid.BorderColor = System.Drawing.Color.Black;
                var header = new TableHeaderRow();
                header.Font.Bold = true;
                for (int i = 0; i < eigenschaften.Length; i++)
                {
                    var cell = new TableHeaderCell();
                    cell.Text = eigenschaften[i];
                    header.Cells.Add(cell);
                }
                grid.Rows.Add(header);


                SqlCon.sqlConnection.Open();
              
                if (objekt.SelectedValue != "Computer") { 
                    SqlCon.command = new SqlCommand("exec dbo.getInventar " + objekt.SelectedValue + "," + orte.SelectedValue + "," 
                        + auswahlraum.SelectedValue, SqlCon.sqlConnection);
                }
                else {
                    SqlCon.command = new SqlCommand("exec dbo.getComputer " + orte.SelectedValue + "," + auswahlraum.SelectedValue + "," + auswahlcpu.SelectedValue +
                        "," + auswahlram.SelectedValue + "," + auswahlhdd.SelectedValue + "," + auswahlssd.SelectedValue + "," + auswahlgrafik.SelectedValue, SqlCon.sqlConnection);
                }

                SqlCon.reader = SqlCon.command.ExecuteReader();
                while (SqlCon.reader.Read())
                {
                    var row = new TableRow();


                    string name = "";
                    if (objekt.SelectedItem.ToString() == "Computer")
                    
                        name = SqlCon.reader["Computername"].ToString();
                    
                    else  
                        name = objekt.SelectedItem.ToString() + " " + SqlCon.reader[objekt.SelectedItem.ToString() + "Id"].ToString();

                    var cell = new TableCell();
                    cell.Text = name; row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = SqlCon.reader["Position"].ToString(); row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = SqlCon.reader["Raum"].ToString(); row.Cells.Add(cell);

                    //infobutton für weiterleitung, im Tabindex inventarnummerspeichern
                    infobutton = new Button();
                    infobutton.Text = "+";

                    infobutton.TabIndex = Convert.ToInt16(SqlCon.reader["InventarId"]);
                    cell = new TableCell();
                    cell.Controls.Add(infobutton); row.Cells.Add(cell);
                    infobutton.Click += Infobutton_Click;
                    grid.Rows.Add(row);
                    
                }



                SqlCon.reader.Close();
                SqlCon.sqlConnection.Close();

            }
            catch (Exception)
            {
                SqlCon.reader.Close();
                SqlCon.sqlConnection.Close();
            }

        }

        protected void erfassen_Click(object sender, EventArgs e)
        {
            grid.Visible = true;
            controls.Visible = false;
        }

        protected void Infobutton_Click(object sender, EventArgs e)
        {
            inventarnummer = (sender as Button).TabIndex + "";
            obj.Controls.Add(new Objekt(inventarnummer).getObjekt());
            obj.Visible = true;
            controls.Visible = true;
            grid.Visible = false;

        }
   
        protected void auswahl_Click(object sender, EventArgs e)
        {
            set_visibility();
         
            auswahlraum.Items.Clear();auswahlcpu.Items.Clear();
            auswahlgrafik.Items.Clear();auswahlram.Items.Clear();
            auswahlhdd.Items.Clear();auswahlssd.Items.Clear();
            try
            {

                SqlCon.sqlConnection.Open();
                SqlCon.command = new SqlCommand("exec dbo.getRaum " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlraum.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlraum.Items.Add(SqlCon.reader["raum"].ToString());
                }
                SqlCon.reader.Close();
                SqlCon.command = new SqlCommand("exec dbo.getcpu " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlcpu.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlcpu.Items.Add(SqlCon.reader["prozessor"].ToString());
                }
                SqlCon.reader.Close();
                SqlCon.command = new SqlCommand("exec dbo.getram " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlram.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlram.Items.Add(SqlCon.reader["RAM"].ToString());
                }
                SqlCon.reader.Close();
                SqlCon.command = new SqlCommand("exec dbo.gethdd " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlhdd.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlhdd.Items.Add(SqlCon.reader["hdd"].ToString());
                }
                SqlCon.reader.Close();
                SqlCon.command = new SqlCommand("exec dbo.getssd " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlssd.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlssd.Items.Add(SqlCon.reader["ssd"].ToString());
                }
                SqlCon.reader.Close();
                SqlCon.command = new SqlCommand("exec dbo.getgrafik " + orte.SelectedValue, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();
                auswahlgrafik.Items.Add("''");
                while (SqlCon.reader.Read())
                {
                    auswahlgrafik.Items.Add(SqlCon.reader["Grafik"].ToString());
                }




                SqlCon.reader.Close();
                SqlCon.sqlConnection.Close();

            }
            catch (Exception)
            {
                SqlCon.reader.Close();
                SqlCon.sqlConnection.Close();

            }

        }

        protected void poschange_Click(object sender, EventArgs e)
        {
            SqlCon.sqlConnection.Open();
            SqlCon.command = new SqlCommand("exec dbo.updatePos @invid,@pos", SqlCon.sqlConnection);
            SqlCon.command.Parameters.Add(new SqlParameter("invid", inventarnummer));
            SqlCon.command.Parameters.Add(new SqlParameter("pos", poschtxt.Text));
            SqlCon.command.ExecuteNonQuery();
            SqlCon.sqlConnection.Close();
            obj.Controls.Add(new Objekt(inventarnummer).getObjekt());
        }

        protected void raumchange_Click(object sender, EventArgs e)
        {
            SqlCon.sqlConnection.Open();
            SqlCon.command = new SqlCommand("exec dbo.updateRaum @invid,@raum", SqlCon.sqlConnection);
            SqlCon.command.Parameters.Add(new SqlParameter("invid", inventarnummer));
            SqlCon.command.Parameters.Add(new SqlParameter("raum", raumchtxt.Text));
            SqlCon.command.ExecuteNonQuery();
            SqlCon.sqlConnection.Close();
            obj.Controls.Add(new Objekt(inventarnummer).getObjekt());

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            controls.Visible = false;
        }
        private void set_visibility()
        {
            grid.Visible = false;
            erfassen.Visible = true;
            auswahlraum.Visible = true;
            raumtxt.Visible = true;
            controls.Visible = false;
            cputxt.Visible = false;
            auswahlcpu.Visible = false;
            ramtxt.Visible = false;
            auswahlram.Visible = false;
            grafiktxt.Visible = false;
            auswahlgrafik.Visible = false;
            hddtxt.Visible = false;
            auswahlhdd.Visible = false;
            ssdtxt.Visible = false;
            auswahlssd.Visible = false;
            if (objekt.SelectedItem.ToString() == "Computer")
            {
                cputxt.Visible = true;
                auswahlcpu.Visible = true;
                ramtxt.Visible = true;
                auswahlram.Visible = true;
                grafiktxt.Visible = true;
                auswahlgrafik.Visible = true;
                hddtxt.Visible = true;
                auswahlhdd.Visible = true;
                ssdtxt.Visible = true;
                auswahlssd.Visible = true;
            }
        }
    }
}