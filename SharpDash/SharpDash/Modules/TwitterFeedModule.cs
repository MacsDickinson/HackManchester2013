using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Raven.Client;
using SharpDash.Domain.Session;
using SharpDash.Requests;

namespace SharpDash.Modules
{
    public class TwitterFeedModule : NancyModule
    {
        public TwitterFeedModule(IDocumentSession documentSession)
            : base("/TwitterFeed")
        {
            this.RequiresAuthentication();
                

            Get["/"] = _ =>
            {
                var user = (UserIdentity)this.Context.CurrentUser;
                return this.Negotiate.WithModel(user.TwitterFeeds);
            };

            Post["/"] = _ =>
            {
                var user = (UserIdentity)this.Context.CurrentUser;

                var twitterFeed = this.Bind<TwitterFeedRequest>();
                var databaseUser = documentSession.Load<UserIdentity>(user.Id);

                if (databaseUser.TwitterFeeds == null)
                    databaseUser.TwitterFeeds = new List<string>();

                databaseUser.TwitterFeeds.Add(twitterFeed.Name);
                return HttpStatusCode.Created;
            };
        }
    }
}