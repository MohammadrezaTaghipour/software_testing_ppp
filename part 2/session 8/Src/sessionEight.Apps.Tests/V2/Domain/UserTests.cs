
using FluentAssertions;
using sessionEight.Apps.V2.Domain;
using Xunit;

namespace sessionEight.Apps.Tests.V2.Domain;

public class UserTests
{
    [Fact]
    public void Changing_email_from_non_corporate_to_corporate()
    {
        //Arrange
        var sut = new User(1, "mamreza@gmail.com", UserType.Customer);
        var company = new Company("edsab.ir", 0);
        
        //Act
        sut.ChangeEmail("mamareza@edsab.ir", company);

        //Assert
        sut.Email.Should().Be("mamareza@edsab.ir");
        sut.Type.Should().Be(UserType.Employee);
        company.NumberOfEmployees.Should().Be(1);
    }

    [Fact]
    public void Changing_email_from_corporate_to_non_corporate()
    {
        //Arrange
        var sut = new User(1, "mamreza@edsab.ir", UserType.Employee);
        var company = new Company("edsab.ir", 1);
        
        //Act
        sut.ChangeEmail("mamareza@gmail.com", company);

        //Assert
        sut.Email.Should().Be("mamareza@gmail.com");
        sut.Type.Should().Be(UserType.Customer);
        company.NumberOfEmployees.Should().Be(0);
    }

    [Fact]
    public void Changing_email_without_changing_user_type()
    {
        //Arrange
        var sut = new User(1, "mamreza@gmail.com", UserType.Customer);
        var company = new Company("edsab.ir", 0);
        
        //Act
        sut.ChangeEmail("mamareza-edited@gmail.ir", company);

        //Assert
        sut.Email.Should().Be("mamareza-edited@gmail.ir");
        sut.Type.Should().Be(UserType.Customer);
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
        company.NumberOfEmployees.Should().Be(0);
    }
}