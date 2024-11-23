using Microsoft.EntityFrameworkCore;
using sessionTen.App.Infrastructure.Data;
using Testcontainers.MsSql;

namespace sessionTen.App.Tests.Integrations.Services.V3;

public class IntegrationFixture
{
    private readonly MsSqlContainer _container;
    
    public IntegrationFixture()
    {
        _container= new MsSqlBuilder()
            .WithCleanUp(true)
            .Build();

        _container.StartAsync().GetAwaiter().GetResult();
    }
    
    public async Task<AppDbContext> CreateContext()
    {
        var connectionString = _container.GetConnectionString();

        var dbContext = new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options);

        await dbContext.Database.EnsureCreatedAsync();

        return dbContext;
    }
}