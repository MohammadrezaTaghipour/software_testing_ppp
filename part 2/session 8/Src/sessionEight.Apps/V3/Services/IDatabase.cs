using sessionEight.Apps.V3.Domain;

namespace sessionEight.Apps.V3.Services;

public interface IDatabase
{
    User GetUserById(int id);
    
    Company GetCompany();
    
    void SaveCompany(Company company);
    
    void SaveUser(User user);
}