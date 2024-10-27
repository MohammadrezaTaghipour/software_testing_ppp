using NSubstitute;
using sessionSeven.App.UnitTestingStyles.CommunicationBased;
using Xunit;

namespace sessionSeven.App.Tests.UnitTestingStyles.CommunicationBased;

// This style of unit testing is communication-based testing.
// This style uses mocks to verify communications between the system under test and its collaborators.
public class OrdersControllerTests
{
    [Fact]
    public void Sending_a_greetings_email()
    {
        //Arrange
        var emailGatewayMock = Substitute.For<IEmailGateway>();
        var sut = new OrdersController(emailGatewayMock);

        //Act
        sut.GreetUser("user@email.com");

        //Assert
        emailGatewayMock.Received(1).SendGreetingsEmail("user@email.com");
    }
}