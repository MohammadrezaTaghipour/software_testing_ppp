namespace sessionSeven.App.UnitTestingStyles.CommunicationBased;

public class OrdersController(IEmailGateway emailGateway)
{
    public void GreetUser(string email)
    {
        emailGateway.SendGreetingsEmail(email);
    }
}