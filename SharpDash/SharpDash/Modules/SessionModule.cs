using Nancy;
using Nancy.Authentication.Forms;

namespace SharpDash.Modules
{
    public class SessionModule : NancyModule
    {
        public SessionModule()
            : base("/Session")
        {
            Get["Login"] = _ => View["Login"];

            Get["Logout"] = _ => this.LogoutAndRedirect("~/Session/Login");
        }
    }
}