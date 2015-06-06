using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class signIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var ctx = new CarRenterContext())
            {
                var user = (from a in ctx.Agencies
                            where a.UserName == txtName.Text && a.Password == txtPassword.Text
                            select a).FirstOrDefault();

                if (user != null)
                {
                    // Save user id in a session
                    Session["LoggedInId"] = user.AgencyId.ToString();

                    // Redirect to home page
                    Response.Redirect("home.aspx");
                }
            }
        }
    }
}