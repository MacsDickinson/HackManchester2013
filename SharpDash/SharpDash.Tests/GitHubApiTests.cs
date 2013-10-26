using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using SharpDash.Domain.GitHub;

namespace SharpDash.Tests
{
    [TestFixture]
    public class GitHubApiTestsTests
    {
        [Test]
        public void Can_get_events_for_repo()
        {
            // Arrange
            var client = new RestClient{
                                 BaseUrl = "https://api.github.com",
                                 Authenticator = new HttpBasicAuthenticator("autonomatt", "G17hu8")
                             };
            var request = new RestRequest("repos/macsdickinson/hackmanchester2013/events");
            client.AddHandler("text/plain", new JsonDeserializer());

            // Act
            var response = client.Execute<List<Event>>(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Count > 0);
        }
    }
}