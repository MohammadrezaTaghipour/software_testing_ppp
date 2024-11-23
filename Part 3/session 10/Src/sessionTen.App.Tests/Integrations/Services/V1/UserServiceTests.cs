using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using sessionTen.App.Application;
using sessionTen.App.Domain;
using sessionTen.App.Infrastructure.Data;
using sessionTen.App.Infrastructure.Framework;
using Testcontainers.MsSql;
using Xunit;

namespace sessionTen.App.Tests.Integrations.Services.V1;

public class UserServiceTests
{
    [Fact]
    public async Task Changing_email_from_non_corporate_to_corporate()
    {
        //Arrange
        var dbContext = await CreateContext();
        var database = new MssqlDatabase(dbContext);
        var eventDispatcher = Substitute.For<IEventDispatcher>();
        var sut = new UserService(database, eventDispatcher);

        var company = new Company(1, "edsub.ir", 0);
        dbContext.Companies.Add(company);

        var user = new User(1, "user@gmail.com", company);
        dbContext.Users.Add(user);

        await dbContext.SaveChangesAsync();

        var request = new ChangeUserEmailRequest
        {
            Id = user.Id,
            NewEmail = "user@edsub.ir"
        };

        //Act
        await sut.ChangeEmail(request);


        //Assert
        var userActual = await dbContext.Users.FirstAsync(a => a.Id == user.Id);
        userActual.Email.Should().Be(request.NewEmail);
        userActual.Type.Should().Be(UserType.Employee);
        
        
        var companyActual = await dbContext.Companies.FirstAsync(a => a.Id == company.Id);
        companyActual.NumberOfEmployees.Should().Be(1);

        eventDispatcher.Received(1).Dispatch(Arg.Any<IReadOnlyList<IDomainEvent>>());
    }

    private async Task<AppDbContext> CreateContext()
    {
        var dbContainer = new MsSqlBuilder()
            .WithCleanUp(true)
            .Build();

        await dbContainer.StartAsync();

        var connectionString = dbContainer.GetConnectionString();

        var dbContext = new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options);

        await dbContext.Database.EnsureCreatedAsync();

        return dbContext;
    }
}