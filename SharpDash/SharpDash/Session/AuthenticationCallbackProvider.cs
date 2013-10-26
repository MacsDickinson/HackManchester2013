using System;
using Nancy;
using Nancy.SimpleAuthentication;
using Raven.Client;

namespace SharpDash.Session
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        private readonly IDocumentSession _documentSession;

        public AuthenticationCallbackProvider(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            if (model.Exception == null)
            {
                var userInformation = model.AuthenticatedClient.UserInformation;
                var providerName = model.AuthenticatedClient.ProviderName;
            }

            throw new NotImplementedException();

        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}