using BlazorWASM_EF.Shared.Models;
using System.Net;

namespace BlazorWASM_EF.Client.Contracts
{
    public interface IEF_Test_Service
    {
        event Action? OnChange;
        void Update();

        Task<List<TestDataModel>> Get();
        Task<TestDataModel> Get(int id);
        Task<HttpStatusCode> Put(TestDataModel data);
        Task<HttpStatusCode> Post(TestDataModel data);
        Task<HttpStatusCode> Delete(int id);
    }
}