using System.Dynamic;
using System.Linq;
using Nancy;
using Raven.Client;
using SharpDash.Domain.GitHub;
using SharpDash.ViewModels;

namespace SharpDash.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule(IDocumentSession documentSession)
        {
            Get["/event"] = ಠ_ಠ =>
            {
                var model = new IndexViewModel {Events = documentSession.Query<Event>().ToList()};
                return View["Index", model];
            };

            Post["/add-event"] = ಠ_ಠ =>
            {
                var newEvent = new Event();
                documentSession.Store(newEvent);

                return newEvent.Id;
            };
        }
    }
}