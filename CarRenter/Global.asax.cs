﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CarRenter
{
    public class Global : System.Web.HttpApplication
    {
        public int CurrentCityId { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}