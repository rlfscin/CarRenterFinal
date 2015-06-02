using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace CarRenter.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public bool Available { get; set; }

        public string Image { get; set; }
    }
}