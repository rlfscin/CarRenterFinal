using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class rent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("home.aspx");
            }

            if (!Page.IsPostBack)
            {
                LoadCars();
            }
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected car id
                int carId = Convert.ToInt32(drpCar.SelectedValue);

                // Get selected return date
                DateTime returnDate = cldReturnDate.SelectedDate;

                // Get current city id
                int cityId = GetCityID(Int32.Parse(Session["LoggedInId"].ToString()));

                // Add a new rental and update car's availability
                using (var ctx = new CarRenterContext())
                {
                    Rental r = ctx.Rentals.Create();
                    r.CarId = carId;
                    r.CityId = cityId;
                    r.RentDate = DateTime.Now;
                    r.ReturnDate = returnDate;

                    ctx.Rentals.Add(r);

                    Car car = ctx.Cars.Where(c => c.CarId == carId).FirstOrDefault();
                    car.Available = false;

                    ctx.SaveChanges();
                }
            }
            catch (Exception) { }
        }

        private void LoadCars()
        {
            // Get current car's city id
            int cityId = this.GetCityID(Int32.Parse(Session["LoggedInId"].ToString()));

            using (var ctx = new CarRenterContext())
            {
                var cars = ctx.Cars.Where(c => c.CityId == cityId && c.Available == true).ToList();

                foreach (var car in cars)
                {
                    ListItem li = new ListItem();
                    li.Text = car.Name;
                    li.Value = car.CarId.ToString();

                    drpCar.Items.Add(li);
                }

                if (cars != null)
                {
                    imgCar.ImageUrl = cars[0].Image;
                    lblCar.Text = cars[0].Name;
                    lblStatus.Text = cars[0].Available ? "Available" : "Unavailable";
                }
            }
        }

        private int GetCityID(int agencyId)
        {
            using (var ctx = new CarRenterContext())
            {
                return ctx.Agencies.Where(a => a.AgencyId == agencyId).Select(a => a.CityId).FirstOrDefault();
            }
        }

        protected void drpCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new CarRenterContext())
            {
                int carId = Int32.Parse(drpCar.SelectedValue);

                var car = ctx.Cars.Where(c => c.CarId == carId).FirstOrDefault();

                if (car != null)
                {
                    imgCar.ImageUrl = car.Image;
                    lblCar.Text = car.Name;
                    lblStatus.Text = car.Available ? "Available" : "Unavailable";
                }
            }
        }
    }
}