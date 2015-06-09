using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class search : System.Web.UI.Page
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
                this.LoadCars();
                this.LoadRentalData(Int32.Parse(drpCar.SelectedValue));
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

                if (cars[0] != null)
                {
                    imgCar.ImageUrl = cars[0].Image;
                    lblCar.Text = cars[0].Name;
                    lblStatus.Text = cars[0].Available ? "Available" : "Unavailable";
                }
            }
        }

        protected void drpCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadRentalData(Int32.Parse(drpCar.SelectedValue));

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

        #endregion

        #region [ Methods ]

        private void LoadRentalData(int carId)
        {
            using (var ctx = new CarRenterContext())
            {
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

        #endregion
    }
}