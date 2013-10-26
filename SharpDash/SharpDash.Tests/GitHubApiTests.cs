using NUnit.Framework;
using RestSharp;
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
            var client = new RestClient("https://api.github.com")
            var request = new RestRequest("/repos/macsdickinson/hackmanchester2013/events", Method.GET);

            // Act
            var response = client.Execute<Event>(request)

            // Assert

        }
    }
}