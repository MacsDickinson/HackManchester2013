using Nancy;
using Nancy.Security;

namespace SharpDash.Modules
{
    public class DashboardModule : NancyModule
    {
        public DashboardModule()
        {
            this.RequiresAuthentication();

            Get["/"] = _ => View["Index"];
        }
    }
}