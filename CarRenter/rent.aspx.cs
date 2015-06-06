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
                if (Request.QueryString["carId"] != null)
                {
                    LoadCars(Int32.Parse(Request.QueryString["carId"].ToString()));
                }
                else
                {
                    LoadCars();
                }
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
                int cityId = GetCity(Int32.Parse(Session["LoggedInId"].ToString()));

                // Add a new rental and update car's availability
                using (var ctx = new CarRenterContext())
                {
                    Rental r = new Rental();
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

        private void LoadCars(int carId = 0)
        {
            List<Car> cars = null;

            // Get current car's city id
            int cityId = this.GetCity(Int32.Parse(Session["LoggedInId"].ToString()));

            using (var ctx = new CarRenterContext())
            {
                cars = ctx.Cars.Where(c => c.CityId == cityId && c.Available == true).ToList();

                cars = carId != 0 ? cars.Where(c => c.CarId == carId).ToList() : cars;
            }

            foreach (var car in cars)
            {
                ListItem li = new ListItem();
                li.Text = car.Name;
                li.Value = car.CarId.ToString();

                drpCar.Items.Add(li);
            }
        }

        private int GetCity(int agencyId)
        {
            using (var ctx = new CarRenterContext())
            {
                return ctx.Agencies.Where(a => a.AgencyId == agencyId).Select(a => a.CityId).FirstOrDefault();
            }
        }
    }
}