namespace sessionFive.App.ObservableBehavior;

public class Employee
{
    public string Name { get; set; }
    public IReadOnlyCollection<Contract> Contracts => _contracts.AsReadOnly();

    private List<Contract> _contracts;
    
    public void AddContract(Contract contract)
    {
        //TODO: check invairants
        
        
        _contracts.Add(contract);
    }
}


public class Contract
{
    public DateTime StartFrom { get; set; }
    public DateTime? EndFrom { get; set; }
}