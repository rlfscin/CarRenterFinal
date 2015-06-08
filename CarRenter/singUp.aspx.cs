using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class singUp : System.Web.UI.Page
    {
        #region [ Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                // Return to home page
                Response.Redirect("home.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.LoadCities();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtName.Text;
                string password = txtPassword.Text;
                int cityId = Int32.Parse(drpCity.SelectedValue);

                using (var ctx = new CarRenterContext())
                {
                    if (chkOtherCity.Checked)
                    {
                        City c = ctx.Cities.Create();
                        c.Name = txtOtherCity.Text;

                        ctx.Cities.Add(c);
                        ctx.SaveChanges();

                        cityId = c.CityId;
                    }

                    Agency a = ctx.Agencies.Create();
                    a.CityId = cityId;
                    a.UserName = userName;
                    a.Password = password;

                    ctx.Agencies.Add(a);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region [ Methods ]

        private void LoadCities()
        {
            using (var ctx = new CarRenterContext())
            {
                var cities = ctx.Cities.ToList();

                foreach (var city in cities)
                {
                    ListItem li = new ListItem();
                    li.Text = city.Name;
                    li.Value = city.CityId.ToString();

                    drpCity.Items.Add(li);
                }
            }
        }

        #endregion
    }
}