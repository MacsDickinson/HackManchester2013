﻿using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SharpDash.Raven
{
    public class RavenSessionProvider
    {
        private static DocumentStore _documentStore;

        public bool SessionInitialized { get; set; }

        public static DocumentStore DocumentStore
        {
            get { return (_documentStore ?? (_documentStore = CreateDocumentStore())); }
        }

        private static DocumentStore CreateDocumentStore()
        {
            var store = new DocumentStore
            {
                Url = ConfigurationManager.AppSettings["RAVENHQ_URI"],
                DefaultDatabase = ConfigurationManager.AppSettings["RAVENHQ_Database"],
                ApiKey = ConfigurationManager.AppSettings["RAVENHQ_APIKEY"],
            };
            store.Initialize();

            return store;
        }
    }
}