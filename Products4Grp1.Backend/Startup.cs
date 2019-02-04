using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Products4Grp1.Backend.Startup))]
namespace Products4Grp1.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
