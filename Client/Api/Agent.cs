using Blazored.Toast.Services;
using Client.Models;
using Client.Stores;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        //private readonly string _baseUrl = "https://192.168.178.137:45455/api";

        private readonly HttpClient _client;
        private readonly RootStore _storage;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _js;
        private readonly IToastService _toastService;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Agent(HttpClient client,
                     RootStore storage,
                     NavigationManager navigationManager,
                     IJSRuntime js,
                     IToastService toastService)
        {
            _client = client;
            _storage = storage;
            _navigationManager = navigationManager;
            _js = js;
            _toastService = toastService;
        }

        public async Task<HttpResponseMessage> Login(LoginUserForm userFormValues)
        {
            var json = JsonSerializer.Serialize(userFormValues);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Post("/user/login", content);

            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(stringContent, _jsonSerializerOptions);
                _storage.CurrentUser = user;
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
                _storage.CurrentUser = user;
            }

            return response;
        }

        public async Task<List<Activity>> GetActivities()
        {
            await Authorize();

            var response = await Get("/activities");
            var content = await response.Content.ReadAsStringAsync();
            var activities = JsonSerializer.Deserialize<List<Activity>>(content, _jsonSerializerOptions);

            if (response.IsSuccessStatusCode)
            {
                //_storage.Activities = activities;
                return activities;
            }
            else
                return null;
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

        private async Task Authorize()
        {
            var storeJson = await _js.InvokeAsync<string>("state.load", "Store");
            var store = JsonSerializer.Deserialize<RootStore>(storeJson);
            var user = store.CurrentUser;

            if (!_client.DefaultRequestHeaders.Contains("Authorization"))
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.Token);
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