using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(komssionka.Startup))]
namespace komssionka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
