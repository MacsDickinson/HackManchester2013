using System;
using System.Collections.Generic;
using Nancy.Security;

namespace SharpDash.Domain.Session
{
    public class UserIdentity : IUserIdentity
    {
        public Guid Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }
        public string ProviderUsername { get; set; }

        public string UserName
        {
            get
            {
                return ProviderId + "-" + ProviderName;
            } 
        }

        public IEnumerable<string> Claims { get; private set; }
    }
}
