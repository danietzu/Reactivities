using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Reactivities.Blazor.Data;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Reactivities.Blazor.Api
{
    public class Agent
    {
        private readonly string _baseUrl = "https://localhost:4000/api";
        private readonly HttpClient _client;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _js;
        private readonly IToastService _toastService;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Agent(HttpClient client,
                     NavigationManager navigationManager,
                     IJSRuntime js,
                     IToastService toastService)
        {
            _client = client;
            _navigationManager = navigationManager;
            _js = js;
            _toastService = toastService;
            //_client.DefaultRequestHeaders ...
        }

        public async Task<List<Activity>> ListActivities()
        {
            var response = await _get("/activities");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Activity>>(content, _jsonSerializerOptions);
        }

        public async Task<Activity> GetActivity(string id)
        {
            var response = await _get($"/activities/{id}");
            var content = await response.Content.ReadAsStringAsync();

            // TODO: handle Network Error

            if (response.StatusCode == HttpStatusCode.NotFound ||
                response.StatusCode == HttpStatusCode.BadRequest)
            {
                _navigationManager.NavigateTo("error");
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                _toastService.ShowError(response.ReasonPhrase);
                return null;
            }
            else
                return JsonSerializer.Deserialize<Activity>(content, _jsonSerializerOptions);

            return null;
        }

        public async Task<HttpResponseMessage> CreateActivity(Activity activity)
        {
            var json = JsonSerializer.Serialize(activity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await _post("/activities", content);
        }

        public async Task<HttpResponseMessage> UpdateActivity(Activity activity)
        {
            var json = JsonSerializer.Serialize(activity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await _put($"/activities/{activity.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteActivity(string id)
        {
            return await _del($"/activities/{id}");
        }

        private async Task<HttpResponseMessage> _get(string url) =>
            await _client.GetAsync(_baseUrl + url);

        private async Task<HttpResponseMessage> _post(string url, HttpContent content) =>
            await _client.PostAsync(_baseUrl + url, content);

        private async Task<HttpResponseMessage> _put(string url, HttpContent content) =>
             await _client.PutAsync(_baseUrl + url, content);

        private async Task<HttpResponseMessage> _del(string url) =>
            await _client.DeleteAsync(_baseUrl + url);
    }
}