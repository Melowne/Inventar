using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventarverwaltung_iad_asp
{
    internal class FillSitzplan
    {
        public static void load_Computerdaten(string standort, string raum,Page page,Label fehler)
        {
            try
            {
                SqlCon.sqlConnection.Open();
                SqlCon.command = new SqlCommand("exec dbo.getInventar Computer,"+standort+","+raum, SqlCon.sqlConnection);
                SqlCon.reader = SqlCon.command.ExecuteReader();

                while (SqlCon.reader.Read())
                {
                    string tempLbControlName = "lbPC" + SqlCon.reader["Position"].ToString();
                    Label tempLbControl = (Label)page.Master.FindControl("MainContent").FindControl(tempLbControlName);
                    if (tempLbControl != null)
                    {
                        tempLbControl.Text = SqlCon.reader["Computername"].ToString();
                    }

                }


                SqlCon.reader.Close();
                SqlCon.sqlConnection.Close();

            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    fehler.Text = "Daten konnten nicht abgefragt werden: " + ex.Message;
                }
                else
                {
                    fehler.Text = "Daten konnten nicht abgefragt werden!!!";
                }
            }
            finally
            {
                SqlCon.sqlConnection.Close();
            }

        }



    }
}