using InvoiceTask.Data;
using InvoiceTask.Data.Context;
using InvoiceTask.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(InvoiceTask.Startup))]

namespace InvoiceTask
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationContext.Create);
            app.CreatePerOwinContext<userManager>(userManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Customer/Login"),
            });
        }
	}
}
