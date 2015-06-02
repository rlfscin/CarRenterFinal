using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRenter.Models
{
    public class Agency
    {
        public int AgencyId { get; set; }

        public int CityId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}