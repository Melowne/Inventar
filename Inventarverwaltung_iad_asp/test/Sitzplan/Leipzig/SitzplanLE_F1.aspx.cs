using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventarverwaltung_iad_asp
{
    public partial class SitzplanLE_F1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillSitzplan.load_Computerdaten("Leipzig", "F1", Page, lbFehler);
            }
        }
    }
}