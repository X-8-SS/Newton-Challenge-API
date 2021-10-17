using Xunit;
using NewtonChallenge.RestAPI;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace NewtonChallenge.IntegrationTest.VideoGames
{
    public class VideoGameTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public VideoGameTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/v1/video-games-catalog")]
        [InlineData("api/v1/video-games-catalog/2")]
        [InlineData("api/v2/video-games-genre")]
        [InlineData("api/v2/video-games-rating")]
        public async Task VideoGamesAllAsync(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            // Status Code 200-299
            response.EnsureSuccessStatusCode();
            // it returns a json object
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
