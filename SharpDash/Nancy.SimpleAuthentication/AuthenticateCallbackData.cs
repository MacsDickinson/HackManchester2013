﻿using System;
using SimpleAuthentication.Core;

namespace Nancy.SimpleAuthentication
{
    public class AuthenticateCallbackData
    {
        /// <summary>
        /// The authenticated client information, if we have successfully authenticated.
        /// </summary>
        public IAuthenticatedClient AuthenticatedClient { get; set; }

        /// <summary>
        /// Possible Url or partial route to redirect to.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Exception information, if an error has occurred.
        /// </summary>
        public Exception Exception { get; set; }
    }
}