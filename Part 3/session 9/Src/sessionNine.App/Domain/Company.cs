namespace sessionNine.App.Domain;

public class Company
{
    private Company()
    {
    }

    public Company(string subdomain, int numberOfEmployees)
    {
        Subdomain = subdomain;
        NumberOfEmployees = numberOfEmployees;
    }
    
    public Company(int id, string subdomain, int numberOfEmployees)
    {
        Id = id;
        Subdomain = subdomain;
        NumberOfEmployees = numberOfEmployees;
    }

    public int Id { get; private set; } 
    public string Subdomain { get; private set; }
    public int NumberOfEmployees { get; private set; }

    public bool IsCorporateEmail(string email)
    {
        var emailSubdomain = email.Split('@')[1];
        return Subdomain == emailSubdomain;
    }

    public void UpdateEmployeeCount(int delta)
    {
        if (NumberOfEmployees + delta >= 0)
            NumberOfEmployees += delta;
    }
}