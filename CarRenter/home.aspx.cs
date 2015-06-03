using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarRenter.Models;

namespace CarRenter
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                singIn.Visible = true;
                singOut.Visible = false;
                loggedSpace.Visible = true;
                logged.Visible = false;
            }
            else
            {
                singIn.Visible = false;
                singOut.Visible = true;
                loggedSpace.Visible = false;
                logged.Visible = true;
            }

            //cities
            using (var context = new CarRenterContext())
            {
                var cities = context.Cities;
                foreach (var city in cities)
                {
                    ListItem li = new ListItem();
                    li.Text = city.Name;
                    li.Value = city.CityId.ToString();
                    ddCity.Items.Add(li);
                }
            }


            using (var contex = new CarRenterContext())
            {
                var cars = contex.Cars.ToList();
                lstCars.DataSource = cars;
                lstCars.DataBind();
            }

        }
    }
}