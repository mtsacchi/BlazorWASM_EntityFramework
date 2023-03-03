using BlazorWASM_EF.Shared.Models;

namespace BlazorWASM_EF.Shared.Factories
{
    public static class Factory
    {
        public static TestDataModel CreateNewTestDataLine() { return new TestDataModel(); }
        public static List<TestDataModel> CreateNewTestDataList() { return new List<TestDataModel>(); }
    }
}
