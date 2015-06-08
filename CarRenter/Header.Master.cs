using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

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

                this.LoadGreeting();
            }
        }

        private void ShowMenus(bool isLogged)
        {
            singIn.Visible = !isLogged;
            loggedSpace.Visible = !isLogged;

            signUp.Visible = isLogged;
            signOut.Visible = isLogged;
            logged.Visible = isLogged;
            lblGreeting.Visible = isLogged;
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();

            // Redirect to home page
            Response.Redirect("home.aspx");
        }

        private void LoadGreeting()
        {
            using (var ctx = new CarRenterContext())
            {
                int agencyId = Int32.Parse(Session["LoggedInId"].ToString());

                var agency = (from a in ctx.Agencies
                              where a.AgencyId == agencyId
                              select new
                              {
                                  UserName = a.UserName,
                                  City = (from c in ctx.Cities where c.CityId == a.CityId select c.Name).FirstOrDefault()
                              }).FirstOrDefault();

                if (agency != null)
                {
                    lblGreeting.Text = "Hello " + agency.UserName + ", from " + agency.City + "!";
                }
            }
        }
    }
}