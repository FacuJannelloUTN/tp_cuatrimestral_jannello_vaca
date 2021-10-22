using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "TP Cuatrimestral Jannello-Vaca";
        }

        protected void utnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/", false);
        }
    }
}