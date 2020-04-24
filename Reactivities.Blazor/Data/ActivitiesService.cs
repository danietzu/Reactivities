using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Reactivities.Blazor.Data
{
    public class ActivitiesService
    {
        private readonly HttpClient _httpClient;
        private static Activity[] Activities;

        public ActivitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Activity[]> GetActivities()
        {
            var str = await _httpClient.GetStringAsync("https://localhost:4000/api/activities");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            Activities = JsonSerializer.Deserialize<Activity[]>(str, options);

            return await Task.FromResult(Activities);
        }
    }
}