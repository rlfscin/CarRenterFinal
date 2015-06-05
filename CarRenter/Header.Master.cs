using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRenter
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                singIn.Visible = true;
                singOut.Visible = false;
                loggedSpace.Visible = true;
                logged.Visible = false;
            }
            else
            {
                singIn.Visible = false;
                singOut.Visible = true;
                loggedSpace.Visible = false;
                logged.Visible = true;
            }
        }
    }
}