using FluentAssertions;
using sessionNine.App.Domain;
using Xunit;

namespace sessionNine.App.Tests.Units.Domain;

public class UserTests
{
    [Fact]
    public void Changing_email_from_non_corporate_to_corporate()
    {
        //Arrange
        var email = "mamreza@gmail.com";
        var newEmail = "mamareza@edsab.ir";
        var newType = UserType.Employee;

        var company = new Company(1, "edsab.ir", 0);
        var sut = new User(1, email, company);
        var expectedEvent = new UserEmailChanged(sut.Id, email, newEmail);
        var expectedEvent2 = new UserTypeChanged(sut.Id, newEmail, sut.Type, newType);

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        sut.Email.Should().Be(newEmail);
        sut.Type.Should().Be(newType);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent2);
        company.NumberOfEmployees.Should().Be(1);
    }

    [Fact]
    public void Changing_email_from_corporate_to_non_corporate()
    {
        //Arrange
        var email = "mamreza@edsab.ir";
        var newEmail = "mamareza@gmail.com";
        var newType = UserType.Customer;

        var company = new Company(1, "edsab.ir", 0);
        var sut = new User(1, email, company);
        var expectedEvent = new UserEmailChanged(sut.Id, email, newEmail);
        var expectedEvent2 = new UserTypeChanged(sut.Id, newEmail, sut.Type, newType);

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        sut.Email.Should().Be(newEmail);
        sut.Type.Should().Be(newType);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent2);
        company.NumberOfEmployees.Should().Be(0);
    }

    [Fact]
    public void Changing_email_without_changing_user_type()
    {
        //Arrange
        var email = "mamreza@gmail.com";
        var newEmail = "mamareza-edited@gmail.ir";
        var newType = UserType.Customer;

        var company = new Company(1, "edsab.ir", 0);
        var sut = new User(1, email, company);
        var expectedEvent = new UserEmailChanged(sut.Id, email, newEmail);

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        sut.Email.Should().Be(newEmail);
        sut.Type.Should().Be(newType);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        sut.DomainEvents.OfType<UserTypeChanged>().Should().BeNullOrEmpty();
        company.NumberOfEmployees.Should().Be(0);
    }

    [Fact]
    public void Changing_email_to_the_same_one()
    {
        //Arrange
        var email = "mamreza@gmail.com";
        var newEmail = "mamreza@gmail.com";
        var newType = UserType.Customer;

        var company = new Company(1, "edsab.ir", 0);
        var sut = new User(1, email, company);

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        sut.Email.Should().Be(newEmail);
        sut.Type.Should().Be(newType);
        sut.DomainEvents.Should().BeNullOrEmpty();
        company.NumberOfEmployees.Should().Be(0);
    }
}