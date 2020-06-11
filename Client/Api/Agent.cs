using Blazored.Toast.Services;
using Client.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Api
{
    public class Agent
    {
        private readonly string _baseUrl = "https://localhost:4001/api";
        private readonly HttpClient _client;
        private readonly NavigationManager _navigationManager;
        private readonly IToastService _toastService;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Agent(HttpClient client,
                     NavigationManager navigationManager,
                     IToastService toastService)
        {
            _client = client;
            _navigationManager = navigationManager;
            _toastService = toastService;
            //_client.DefaultRequestHeaders ...
        }

        public async Task<HttpResponseMessage> GetCurrentUser()
        {
            var response = await Get("/user");
            var stringContent = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(stringContent, _jsonSerializerOptions);

            if (response.IsSuccessStatusCode)
            {
                // save user in STORE
            }

            return response;
        }

        public async Task<HttpResponseMessage> Login(LoginUserForm userFormValues)
        {
            var json = JsonSerializer.Serialize(userFormValues);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Post("/user/login", content);

            var stringContent = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(stringContent, _jsonSerializerOptions);

            if (response.IsSuccessStatusCode)
            {
                // save user in STORE
            }

            return response;
        }

        public async Task<HttpResponseMessage> Register(RegisterUserForm userFormValues)
        {
            var json = JsonSerializer.Serialize(userFormValues);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Post("/user/register", content);

            var stringContent = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(stringContent, _jsonSerializerOptions);

            if (response.IsSuccessStatusCode)
            {
                // save user in STORE and LOGIN
            }

            return response;
        }

        public async Task<List<Activity>> ListActivities()
        {
            var response = await Get("/activities");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Activity>>(content, _jsonSerializerOptions);
        }

        public async Task<Activity> GetActivity(string id)
        {
            var response = await Get($"/activities/{id}");
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

            return await Post("/activities", content);
        }

        public async Task<HttpResponseMessage> UpdateActivity(Activity activity)
        {
            var json = JsonSerializer.Serialize(activity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await Put($"/activities/{activity.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteActivity(string id)
        {
            return await Delete($"/activities/{id}");
        }

        private async Task<HttpResponseMessage> Get(string url) =>
            await _client.GetAsync(_baseUrl + url);

        private async Task<HttpResponseMessage> Post(string url, HttpContent content) =>
            await _client.PostAsync(_baseUrl + url, content);

        private async Task<HttpResponseMessage> Put(string url, HttpContent content) =>
             await _client.PutAsync(_baseUrl + url, content);

        private async Task<HttpResponseMessage> Delete(string url) =>
            await _client.DeleteAsync(_baseUrl + url);
    }
}