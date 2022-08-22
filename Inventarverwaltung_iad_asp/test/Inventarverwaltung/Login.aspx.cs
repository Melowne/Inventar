using System;


namespace Inventarverwaltung_iad_asp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login.Click += Login_Click;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCon.checkLogin(admin.Text, pass.Text);
                SqlCon.sqlConnection.Open();
                SqlCon.sqlConnection.Close();
                Response.Redirect("~/Inventarverwaltung/Verwaltung.aspx", true);

            }
            catch (Exception)
            {
                Trace.Write(e.ToString());
                SqlCon.sqlConnection.Close();
                SqlCon.checkLogin(admin.Text, pass.Text);
            }

        }
    }
}