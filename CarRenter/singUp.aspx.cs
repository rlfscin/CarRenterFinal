using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class singUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadCities();
            }
        }

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
    }
}