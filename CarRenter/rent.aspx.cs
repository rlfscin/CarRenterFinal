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
        private int AgencyID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                // Return to home page
                Response.Redirect("home.aspx");
            }
            else
            {
                // Store AgencyID value into a local variable coming from user's session
                this.AgencyID = Int32.Parse(Session["LoggedInId"].ToString());
            }

            if (!Page.IsPostBack)
            {
                if (!this.ExistCars())
                {
                    pnlNoCars.Visible = true;
                    pnlCars.Visible = false;

                    lblMessage.Text = "<h1>There are no cars linked to " + this.GetCity().Name + ".</h1>";

                    return;
                }

                LoadCars();
            }
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected CarID
                int carId = Convert.ToInt32(drpCar.SelectedValue);

                // Get selected return date
                DateTime returnDate = cldReturnDate.SelectedDate;

                // Get current city id
                int cityId = GetCity().CityId;

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
            using (var ctx = new CarRenterContext())
            {
                var cars = ctx.Cars.Where(c => c.CityId == this.GetCity().CityId && c.Available == true).ToList();

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

        private bool ExistCars()
        {
            using (var ctx = new CarRenterContext())
            {
                return ctx.Cars.Where(c => c.CityId == this.GetCity().CityId && c.Available).Count() > 0;
            }
        }

        private City GetCity()
        {
            using (var ctx = new CarRenterContext())
            {
                var city = (from c in ctx.Cities
                            where c.CityId == (from a in ctx.Agencies
                                               where a.AgencyId == this.AgencyID
                                               select a.CityId).FirstOrDefault()
                            select c).FirstOrDefault();

                return city;
            }
        }

        protected void drpCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new CarRenterContext())
            {
                var car = ctx.Cars.Where(c => c.CarId == Int32.Parse(drpCar.SelectedValue)).FirstOrDefault();

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