using Client.Config;
using Client.Store;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorState.Shared
{
    public class StateService
    {
        private readonly UserViewModel _model;
        private bool _initializing;
        private readonly HttpClient _client;
        private readonly IStateServiceConfig _config;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            IgnoreReadOnlyProperties = true,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
        };

        public StateService(
            UserViewModel model,
            IStateServiceConfig config,
            HttpClient client)
        {
            _model = model;
            _config = config;
            _client = client;
            _model.PropertyChanged += Model_PropertyChanged;
        }

        public async Task InitAsync()
        {
            _initializing = true;

            var vmJson = await _client.GetStringAsync(_config.Url);
            var vm = JsonSerializer.Deserialize<UserViewModel>(vmJson, _options);
            _model.User = vm.User;

            _initializing = false;
        }

        private async void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_initializing || _config == null)
            {
                return;
            }
            var vm = JsonSerializer.Serialize(_model);
            var content = new StringContent(vm);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _client.PostAsync(_config.Url, content);
        }
    }
}