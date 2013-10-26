using System.Net;
using NUnit.Framework;
using RestSharp;
using SharpDash.Domain.GitHub;

namespace SharpDash.Tests
{
    [TestFixture]
    public class GitHubApiTestsTests
    {
        [Test]
        public void Can_get_events_for_repo_as_raw_content()
        {
            // Arrange
            var client = new RestClient{
                                 BaseUrl = "https://api.github.com",
                                 Authenticator = new HttpBasicAuthenticator("autonomatt", "G17hu8")
                             };
            var request = new RestRequest("repos/macsdickinson/hackmanchester2013/events", Method.GET);

            // Act
            var response = client.Execute<Event>(request);
            //var response = client.Execute(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}