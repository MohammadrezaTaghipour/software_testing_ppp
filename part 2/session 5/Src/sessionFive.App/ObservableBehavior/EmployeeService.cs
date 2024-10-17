namespace sessionFive.App.ObservableBehavior;

public class EmployeeService
{
    public void AddContract()
    {
        var employee = new Employee();
        employee.AddContract(new Contract());
    }
}