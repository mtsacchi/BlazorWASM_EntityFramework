using BlazorWASM_EF.Client.Contracts;
using BlazorWASM_EF.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace BlazorWASM_EF.Client.Services
{
    public class EF_Test_Service : IEF_Test_Service
    {
        public event Action? OnChange;
        public void Update() => OnChange?.Invoke();

        private readonly HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;

        public async Task<List<TestDataModel>> Get()
        {
            _httpResponseMessage = new HttpResponseMessage();

            _httpResponseMessage = await _httpClient.GetAsync("api/testdatamodel");

            if (_httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var serviceResponseData = _httpResponseMessage.Content.ReadFromJsonAsync<List<TestDataModel>>();
                return serviceResponseData.Result;
            }
            
            return null;
        }

        public async Task<TestDataModel> Get(int id)
        {
            _httpResponseMessage = new HttpResponseMessage();
            
            _httpResponseMessage = await _httpClient.GetAsync($"api/testdatamodel/{id}");

            if (_httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var serviceResponseData = _httpResponseMessage.Content.ReadFromJsonAsync<TestDataModel>();
                return serviceResponseData.Result;
            }

            return null;
        }

        public async Task<HttpStatusCode> Post(TestDataModel data)
        {
            _httpResponseMessage = new HttpResponseMessage();

            _httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/testdatamodel", data);

            return _httpResponseMessage.StatusCode;
        }

        public async Task<HttpStatusCode> Put(TestDataModel data)
        {
            _httpResponseMessage = new HttpResponseMessage();

            _httpResponseMessage = await _httpClient.PutAsJsonAsync($"api/testdatamodel/{data.Id}", data);

            return _httpResponseMessage.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            _httpResponseMessage = new HttpResponseMessage();

            _httpResponseMessage = await _httpClient.DeleteAsync($"api/testdatamodel/{id}");

            return _httpResponseMessage.StatusCode;
        }

        public EF_Test_Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
