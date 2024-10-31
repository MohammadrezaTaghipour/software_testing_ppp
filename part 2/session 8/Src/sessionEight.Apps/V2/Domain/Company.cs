namespace sessionEight.Apps.V2.Domain;

public class Company(string companyDomainName, int numberOfEmployees)
{
    public string CompanyDomainName { get; } = companyDomainName;
    public int NumberOfEmployees { get; private set; } = numberOfEmployees;

    public void UpdateNumberOfEmployee(int delta)
    {
        NumberOfEmployees += delta;
    }
}