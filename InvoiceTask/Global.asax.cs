using InvoiceTask.Data.Context;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static InvoiceTask.Data.Context.ApplicationContext;

namespace InvoiceTask
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Database.SetInitializer(new CategoryInitializer<ApplicationContext>());

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			UnityConfig.RegisterComponents();
		}
	}
}
