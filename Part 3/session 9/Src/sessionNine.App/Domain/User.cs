using sessionNine.App.Infrastructure;
using sessionNine.App.Infrastructure.Framework;

namespace sessionNine.App.Domain;

public class User : BaseDomainEntity
{
    private User()
    {
        
    }
    
    public User(int id, string email, Company company)
    {
        Id = id;
        Email = email;

        var type = company.IsCorporateEmail(email) ? UserType.Employee : UserType.Customer;
        var delta = type == UserType.Employee ? 1 : -1;
        company.UpdateEmployeeCount(delta);

        Type = type;
        CompanyId = company.Id;
    }
    
    public User(string email, Company company)
    {
        Email = email;

        var type = company.IsCorporateEmail(email) ? UserType.Employee : UserType.Customer;
        var delta = type == UserType.Employee ? 1 : -1;
        company.UpdateEmployeeCount(delta);

        Type = type;
        CompanyId = company.Id;
    }

    public int Id { get; private set; }
    public string Email { get; private set; }
    public UserType Type { get; private set; }
    public int CompanyId { get; private set; }


    public void ChangeEmail(string newEmail, Company company)
    {
        if (Email == newEmail)
            return;

        var newType = company.IsCorporateEmail(newEmail) ? UserType.Employee : UserType.Customer;

        if (Type != newType)
        {
            var delta = newType == UserType.Employee ? 1 : -1;
            company.UpdateEmployeeCount(delta);
            _domainEvents.Add(new UserTypeChanged(Id, newEmail, Type, newType));
        }

        var emailChanged = new UserEmailChanged(Id, Email, newEmail);

        Email = newEmail;
        Type = newType;

        _domainEvents.Add(emailChanged);
    }
}