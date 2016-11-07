using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGTE_v1._0
{
    public partial class Pruebita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["r"] = int.Parse(codCol.Text);
            Session["t"] = int.Parse(codTalleAper.Text);

            Response.Redirect("AsignarProfesor.aspx");
        }
    }
}