using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMasterPiece.Startup))]
namespace MyMasterPiece
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
