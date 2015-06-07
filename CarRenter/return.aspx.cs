using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class _return : System.Web.UI.Page
    {
        private const double DAILY_PRICE = 50.0;

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
                if (this.ExistCarsToReturn())
                {
                    this.LoadCars();
                }
                else
                {
                    pnlCars.Visible = false;
                    pnlMessage.Visible = true;

                    lblMessage.Text = "<h1>There are no cars to be returned.</h1>";
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new CarRenterContext())
                {
                    // Store selected CarID
                    int carId = Int32.Parse(drpCar.SelectedValue);

                    // Get last car's rental
                    var rental = (from r in ctx.Rentals
                                  where r.CarId == carId
                                  orderby r.RentDate descending
                                  select r).FirstOrDefault();

                    if (rental != null)
                    {
                        // Get current date
                        DateTime currentDate = DateTime.Now;

                        // Subtract the current date to the rent date
                        int totalDays = (currentDate - rental.RentDate).Days;

                        // Normalize value
                        if (totalDays < 1)
                            totalDays = 1;

                        // Multiply total days by daily price
                        double totalPrice = totalDays * DAILY_PRICE;
    
                        // Update car's availabity
                        var car = ctx.Cars.Where(c => c.CarId == carId).FirstOrDefault();
                        car.Available = true;

                        // Update rental's data
                        rental.ReturnDate = currentDate;
                        rental.CityId = this.GetCity().CityId;

                        ctx.SaveChanges();

                        // Show the price on the screen
                        pnlCars.Visible = false;
                        pnlMessage.Visible = true;

                        lblMessage.Text = "<h1>The car has been succesfully returned!</h1></br></br>";
                        lblMessage.Text += "<h1>Total Price: " + totalPrice.ToString("C") + "</h1>";
                    }
                }
            }
            catch (Exception)
            {
                
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

        private bool ExistCarsToReturn()
        {
            using (var ctx = new CarRenterContext())
            {
                return ctx.Cars.Where(c => c.Available == false).Count() > 0;
            }
        }

        private void LoadCars()
        {
            using (var ctx = new CarRenterContext())
            {
                var cars = (from c in ctx.Cars
                            where c.Available == false
                            select c).ToList();

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