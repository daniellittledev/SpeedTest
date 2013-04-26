using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpeedTest
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		//using System.Diagnostics;
		//Stopwatch sw = new Stopwatch();

		public MvcApplication()
			: base()
		{
			var task = new Task(() => {
				AreaRegistration.RegisterAllAreas();

				WebApiConfig.Register(GlobalConfiguration.Configuration);
				FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
				RouteConfig.RegisterRoutes(RouteTable.Routes);

			});

			this.BeginRequest += MvcApplication_BeginRequest;
		}

		void MvcApplication_BeginRequest(object sender, EventArgs e)
		{
			Response.ContentType = "text/html";
			Response.WriteFile(Server.MapPath(@"~\Cache\default.html"));
			Response.End();
			Response.Close();
		}


	}
}