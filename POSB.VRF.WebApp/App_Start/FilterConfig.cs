﻿using System;
using System.Web.Mvc;

namespace POSB.VRF.Webapps.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}