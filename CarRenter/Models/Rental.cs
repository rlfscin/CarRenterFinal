using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRenter.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        public int CarId { get; set; }

        public int CityId { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}