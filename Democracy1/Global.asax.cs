using Democracy1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Democracy1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// La linea 
        /// Database.SetInitializer(new MigrateDatabaseToLatestVersion<DemocracyContext, Migrations.Configuration>());
        /// se coloca para activar las migraciones automaticas
        /// </summary>
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DemocracyContext, Migrations.Configuration>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
