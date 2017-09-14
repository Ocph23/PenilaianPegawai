using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PenilaianPegawaiWeb.Startup))]
namespace PenilaianPegawaiWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
