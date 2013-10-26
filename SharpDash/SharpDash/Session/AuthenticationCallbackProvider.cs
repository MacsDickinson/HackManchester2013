using System;
using System.Linq;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.SimpleAuthentication;
using Raven.Client;
using Raven.Client.Linq;
using SharpDash.Domain.Session;

namespace SharpDash.Session
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        private readonly IDocumentSession _documentSession;

        public AuthenticationCallbackProvider(IDocumentStore documentStore)
        {
            _documentSession = documentStore.OpenSession();
        }

        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            if (model.Exception == null)
            {
                var userInformation = model.AuthenticatedClient.UserInformation;
                var providerName = model.AuthenticatedClient.ProviderName;

                var user = _documentSession.Query<UserIdentity>()
                    .FirstOrDefault(m => m.ProviderId == userInformation.Id && m.ProviderName == providerName);

                if (user == null)
                {
                    user = new UserIdentity
                    {
                        Id = Guid.NewGuid(),
                        ProviderId = userInformation.Id,
                        ProviderName = providerName,
                        ProviderUsername = userInformation.UserName
                    };

                    _documentSession.Store(user);
                    _documentSession.SaveChanges();
                    _documentSession.Dispose();
                }

                return nancyModule.LoginAndRedirect(user.Id);
            }

            nancyModule.ViewBag["ErrorMessage"] = "Authentication has failed";
            return nancyModule.Response.AsRedirect("~/session/login");

        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}