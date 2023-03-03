using BlazorWASM_EF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASM_EF.Server.Data
{
    public class MyPublicGitHubContext : DbContext
    {
        public MyPublicGitHubContext (DbContextOptions<MyPublicGitHubContext> options)
            : base(options)
        {
        }

        public DbSet<TestDataModel> TestData { get; set; } = default!;
    }
}
