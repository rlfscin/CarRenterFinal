using CarRenter.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRenter
{
    public partial class registerCar : System.Web.UI.Page
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
                if (Page.IsValid)
                {
                    if (fuImage.HasFile)
                    {
                        using (var ctx = new CarRenterContext())
                        {
                            Car c = ctx.Cars.Create();
                            c.Name = txtName.Text;
                            c.CityId = Int32.Parse(drpCity.SelectedValue);
                            c.Available = true;
                            c.Image = Path.Combine("car", fuImage.PostedFile.FileName);

                            ctx.Cars.Add(c);
                            ctx.SaveChanges();
                        }

                        // Save image in the server
                        fuImage.PostedFile.SaveAs(Path.Combine(Server.MapPath("~/car/"), Path.GetFileName(fuImage.PostedFile.FileName)));

                        // Redirect to home page
                        Response.Redirect("home.aspx");
                    }
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