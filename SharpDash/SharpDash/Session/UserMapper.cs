using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Raven.Client;
using SharpDash.Domain.Session;

namespace SharpDash.Session
{
    public class UserMapper : IUserMapper
    {
        private readonly IDocumentStore _documentStore;

        public UserMapper(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Load<UserIdentity>(identifier);
            }
        }
    }
}