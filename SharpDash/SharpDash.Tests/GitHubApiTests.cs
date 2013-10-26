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
<<<<<<< HEAD
            var client = new RestClient{
                                 BaseUrl = "https://api.github.com",
                                 Authenticator = new HttpBasicAuthenticator("autonomatt", "G17hu8")
                             };
            var request = new RestRequest("repos/macsdickinson/hackmanchester2013/events", Method.GET);

            // Act
            var response = client.Execute<Event>(request);
            //var response = client.Execute(request);
=======
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/repos/macsdickinson/hackmanchester2013/events", Method.GET);

            // Act
            var response = client.Execute<Event>(request);
>>>>>>> dad48cbba143e7b472306b3bc172ad0db8a1d10b

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}