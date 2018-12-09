using Democracy1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            this.CheckSuperUser();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        private void CheckSuperUser()
        {
            var userContext = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var db = new DemocracyContext();

            this.CheckRole("Admin", userContext);
            this.CheckRole("User", userContext);

            var user = db.Users.Where(u => u.UserName.ToLower
            ().Equals("alejandro.ruiz@correo.policia.gov.co")).FirstOrDefault();

            if (user == null)
            {
                user = new User
                {
                    Address = "Calle Luna Calle Sol",
                    FirstName = "Daniel",
                    LastName = "Ruiz",
                    Phone = "31132982982",
                    UserName = "alejandro.ruiz@correo.policia.gov.co",
                    Photo = "~/Content/Photos/daniel.ruizb.jpeg"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

            var userASP = userManager.FindByName(user.UserName);
            if (userASP == null)
             {               
               userASP = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.UserName,
                PhoneNumber = user.Phone,
            };
                userManager.Create(userASP, "DarbNho_78");
            }
            userManager.AddToRole(userASP.Id, "Admin");
        }

        private void CheckRole(string roleName, ApplicationDbContext userContext)
        {
           
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            //Check to see if role exists, if not create it.

            if (!RoleManager.RoleExists(roleName))
            {
                RoleManager.Create(new IdentityRole(roleName));
            }
        }
    }
}
