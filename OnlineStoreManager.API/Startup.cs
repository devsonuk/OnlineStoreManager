using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using OnlineStoreManager.Repository;
using Owin;

[assembly: OwinStartup(typeof(OnlineStoreManager.API.Startup))]

namespace OnlineStoreManager.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DapperSetup.SetUpDapperExtensions();
        }
    }
}
