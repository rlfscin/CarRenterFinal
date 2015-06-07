using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadCars();
                this.LoadRentalLog();
            }
        }

        private void LoadCars()
        {
            using (var ctx = new CarRenterContext())
            {
                var cars = ctx.Cars.ToList();

                foreach (var car in cars)
                {
                    ListItem li = new ListItem();
                    li.Text = car.Name;
                    li.Value = car.CarId.ToString();

                    drpCar.Items.Add(li);
                }
            }
        }

        private void LoadRentalLog()
        {
            using (var ctx = new CarRenterContext())
            {
                // Store selected CarId
                var carId = Int32.Parse(drpCar.SelectedValue);

                // Retrieve rental information
                var query = from r in ctx.Rentals
                            where r.CarId == carId
                            select new
                            {
                                City = (from c in ctx.Cities where c.CityId == r.CityId select c.Name).FirstOrDefault(),
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate
                            };

                // Bind data
                lstRents.DataSource = query.ToList();
                lstRents.DataBind();
            }
        }

        protected void drpCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadRentalLog();
        }
    }
}