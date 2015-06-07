using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class home : System.Web.UI.Page
    {
        #region [ Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadCities();
                this.LoadCars(Int32.Parse(ddCity.SelectedValue));
            }
        }

        protected void ddCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadCars(Int32.Parse(ddCity.SelectedValue));
        }

        #endregion

        #region [ Methods ]

        private void LoadCars(int cityId)
        {
            using (var ctx = new CarRenterContext())
            {
                lstCars.DataSource = ctx.Cars.Where(c => c.CityId == cityId).ToList();
                lstCars.DataBind();
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

                    ddCity.Items.Add(li);
                }
            }
        }

        #endregion
    }
}