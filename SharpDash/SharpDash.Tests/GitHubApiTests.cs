using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
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

            // Act
            var response = client.Execute<List<Event>>(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public void Can_get_punch_card_data()
        {
            // Arrange
            var client = new RestClient
            {
                BaseUrl = "https://api.github.com",
                Authenticator = new HttpBasicAuthenticator("autonomatt", "G17hu8")
            };
            var request = new RestRequest("repos/macsdickinson/hackmanchester2013/stats/punch_card");

            // Act
            //var response = client.Execute<List<PunchCard>>(request);
            var response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);

            var statistics = new List<Statistic>();
            foreach (var item in result)
            {
                var statistic = new Statistic {Day = item[0], Hour = item[1], Commits = item[2]};
                statistics.Add(statistic);
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}