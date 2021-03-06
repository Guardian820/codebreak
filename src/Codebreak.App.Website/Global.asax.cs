﻿using Codebreak.App.Website.Controllers;
using Codebreak.App.Website.Models.Authservice;
using Codebreak.App.Website.Models.Website;
using Codebreak.App.Website.Models.Worldservice;
using log4net.Config;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;


[assembly: OwinStartup(typeof(Codebreak.App.Website.Signalr.Startup))]
namespace Codebreak.App.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            WebConfig.Instance.Initialize(Server);
            WebDbMgr.Instance.LoadAll(WebConfig.WEB_DB_CONNECTION_STRING);
            AuthDbMgr.Instance.LoadAll(WebConfig.AUTH_DB_CONNECTION_STRING);
            WorldDbMgr.Instance.LoadAll(WebConfig.WORLD_DB_CONNECTION_STRING);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
                HttpContext.Current.User = new AccountTicket(FormsAuthentication.Decrypt(authCookie.Value).Name);            
        }
    }
}