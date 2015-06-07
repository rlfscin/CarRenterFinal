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
                if (this.ExistCarsToRent())
                {
                    LoadCars();
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlCars.Visible = false;

                    lblMessage.Text = "<h1>There are no cars linked to " + this.GetCity().Name + ".</h1>";
                }
            }
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (var ctx = new CarRenterContext())
                    {
                        // Add new rental
                        Rental r = ctx.Rentals.Create();
                        r.CarId = Int32.Parse(drpCar.SelectedValue);
                        r.CityId = GetCity().CityId;
                        r.RentDate = DateTime.Now;
                        r.ReturnDate = cldReturnDate.SelectedDate;

                        ctx.Rentals.Add(r);

                        // Update car's availability
                        Car car = ctx.Cars.Where(c => c.CarId == r.CarId).FirstOrDefault();
                        car.Available = false;

                        // Save changes in the database
                        ctx.SaveChanges();

                        // Show confirmation message
                        pnlCars.Visible = false;
                        pnlMessage.Visible = true;

                        lblMessage.Text = "<h1>The car " + car.Name + " has been succesfully rented!</h1>";
                    }
                }
            }
            catch (Exception) { }
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

        private void LoadCars()
        {
            using (var ctx = new CarRenterContext())
            {
                int cityId = this.GetCity().CityId;

                var cars = ctx.Cars.Where(c => c.CityId == cityId && c.Available == true).ToList();

                foreach (var car in cars)
                {
                    ListItem li = new ListItem();
                    li.Text = car.Name;
                    li.Value = car.CarId.ToString();

                    drpCar.Items.Add(li);
                }

                if (cars[0] != null)
                {
                    imgCar.ImageUrl = cars[0].Image;
                    lblCar.Text = cars[0].Name;
                    lblStatus.Text = cars[0].Available ? "Available" : "Unavailable";
                }
            }
        }

        private bool ExistCarsToRent()
        {
            using (var ctx = new CarRenterContext())
            {
                int cityId = this.GetCity().CityId;

                return ctx.Cars.Where(c => c.CityId == cityId && c.Available).Count() > 0;
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
    }
}