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
            if (Session["LoggedInId"] == null)
            {
                // Not logged
                this.ShowMenus(false);
            }
            else
            {
                // Logged
                this.ShowMenus(true);
            }
        }

        private void ShowMenus(bool isLogged)
        {
            singIn.Visible = !isLogged;
            loggedSpace.Visible = !isLogged;

            signUp.Visible = isLogged;
            signOut.Visible = isLogged;
            logged.Visible = isLogged;
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();

            // Redirect to home page
            Response.Redirect("home.aspx");
        }
    }
}