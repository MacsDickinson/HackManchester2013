﻿using System.Configuration;

namespace SimpleAuthentication.Core.Config
{
    public class ProviderConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Collection of providers to be offered.
        /// </summary>
        [ConfigurationProperty("providers")]
        public ProviderKeyCollection Providers
        {
            get { return (ProviderKeyCollection) this["providers"]; }
        }
    }
}