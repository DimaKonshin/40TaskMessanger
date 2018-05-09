﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "FilterCategoryName",
                routeTemplate: "api/{controller}/{category}/{name}/{skip}"
            );
        }
    }
}
