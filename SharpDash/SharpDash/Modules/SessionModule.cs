using Nancy;

namespace SharpDash.Modules
{
    public class SessionModule : NancyModule
    {
        public SessionModule()
            : base("/Session")
        {
            Get["Login"] = _ => View["Login"];
        }
    }
}