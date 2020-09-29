using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "AuthRepartidorOnline",
                ExpireTimeSpan = TimeSpan.FromMinutes(10),
                LoginPath = new PathString("/Seguridad/Login")
            });
        }
    }
}