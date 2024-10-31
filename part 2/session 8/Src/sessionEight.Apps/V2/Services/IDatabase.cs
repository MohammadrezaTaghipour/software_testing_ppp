using sessionEight.Apps.V2.Domain;

namespace sessionEight.Apps.V2.Services;

public interface IDatabase
{
    User GetUserById(int id);
    
    Company GetCompany();
    
    void SaveCompany(Company company);
    
    void SaveUser(User user);
}