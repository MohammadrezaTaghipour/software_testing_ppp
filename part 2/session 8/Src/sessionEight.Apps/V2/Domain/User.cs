namespace sessionEight.Apps.V2.Domain;

public class User(int userId, string email, UserType userType)
{
    public int UserId { get; private set; } = userId;
    public string Email { get; private set; } = email;
    public UserType Type { get; private set; } = userType;
    public bool IsConfirmed { get; private set; } = true;

    public bool CanChangeEmail()
    {
        return IsConfirmed == true;
    }

    public void ChangeEmail(string newEmail, Company company)
    {
        if (CanChangeEmail() == false)
            throw new Exception("Email is not confirmed yet");

        if (Email == newEmail)
            return;

        string emailDomain = newEmail.Split('@')[1];
        bool isEmailCorporate = emailDomain == company.CompanyDomainName;
        UserType newType = isEmailCorporate
            ? UserType.Employee
            : UserType.Customer;

        if (Type != newType)
        {
            int delta = newType == UserType.Employee ? 1 : -1;
            company.UpdateNumberOfEmployee(delta);
        }

        Email = newEmail;
        Type = newType;
    }
}