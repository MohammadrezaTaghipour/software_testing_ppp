using sessionTen.App.Domain;
using sessionTen.App.Infrastructure.Data;

namespace sessionTen.App.Infrastructure.Framework;

public interface IDatabase
{
    User? GetUser(int userId);
    Company? GetCompany(int companyId);
    Task SaveChanges();
}

public class MssqlDatabase(AppDbContext dbContext) : IDatabase
{
    public User? GetUser(int userId)
    {
        return dbContext.Users.FirstOrDefault(a => a.Id == userId);
    }

    public Company? GetCompany(int companyId)
    {
        return dbContext.Companies.FirstOrDefault(a => a.Id == companyId);
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}