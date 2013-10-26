using Nancy;

namespace SharpDash.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule()
        {
            Get["/"] = ಠ_ಠ =>
                {
                    return View["Index"];
                };
        }
    }
}