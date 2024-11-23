using sessionTen.App.Infrastructure.Framework;

namespace sessionTen.App.Application;

public interface IUserService
{
    Task ChangeEmail(ChangeUserEmailRequest request);
}

public class UserService(IDatabase database, IEventDispatcher eventDispatcher) : IUserService
{
    public async Task ChangeEmail(ChangeUserEmailRequest request)
    {
        var user = database.GetUser(request.Id);
        var company = database.GetCompany(user.CompanyId);

        user.ChangeEmail(request.NewEmail, company);

        await database.SaveChanges();
        eventDispatcher.Dispatch(user.DomainEvents);
    }
}