using FluentAssertions;
using sessionEight.Apps.V3.Domain;
using Xunit;

namespace sessionEight.Apps.Tests.V3.Domain;

public class UserTests
{
    [Fact]
    public void Changing_email_from_non_corporate_to_corporate()
    {
        //Arrange
        var sut = new User(1, "mamreza@gmail.com", UserType.Customer);
        var company = new Company("edsab.ir", 0);
        var expectedEvent = new EmailChangedEvent(sut.UserId, "mamareza@edsab.ir");
        
        //Act
        sut.ChangeEmail("mamareza@edsab.ir", company);

        //Assert
        sut.Email.Should().Be("mamareza@edsab.ir");
        sut.Type.Should().Be(UserType.Employee);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        company.NumberOfEmployees.Should().Be(1);
    }

    [Fact]
    public void Changing_email_from_corporate_to_non_corporate()
    {
        //Arrange
        var sut = new User(1, "mamreza@edsab.ir", UserType.Employee);
        var company = new Company("edsab.ir", 1);
        var expectedEvent = new EmailChangedEvent(sut.UserId, "mamareza@gmail.com");
        
        //Act
        sut.ChangeEmail("mamareza@gmail.com", company);

        //Assert
        sut.Email.Should().Be("mamareza@gmail.com");
        sut.Type.Should().Be(UserType.Customer);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        company.NumberOfEmployees.Should().Be(0);
    }

    [Fact]
    public void Changing_email_without_changing_user_type()
    {
        //Arrange
        var sut = new User(1, "mamreza@gmail.com", UserType.Customer);
        var company = new Company("edsab.ir", 0);
        var expectedEvent = new EmailChangedEvent(sut.UserId, "mamareza-edited@gmail.ir");
        
        //Act
        sut.ChangeEmail("mamareza-edited@gmail.ir", company);

        //Assert
        sut.Email.Should().Be("mamareza-edited@gmail.ir");
        sut.Type.Should().Be(UserType.Customer);
        sut.DomainEvents.Should().ContainEquivalentOf(expectedEvent);
        company.NumberOfEmployees.Should().Be(0);
    }

    [Fact]
    public void Changing_email_to_the_same_one()
    {
        //Arrange
        var sut = new User(1, "mamreza@gmail.com", UserType.Customer);
        var company = new Company("edsab.ir", 0);
        
        //Act
        sut.ChangeEmail("mamreza@gmail.com", company);

        //Assert
        sut.Email.Should().Be("mamreza@gmail.com");
        sut.Type.Should().Be(UserType.Customer);
        sut.DomainEvents.Should().BeNullOrEmpty();
        company.NumberOfEmployees.Should().Be(0);
    }
}