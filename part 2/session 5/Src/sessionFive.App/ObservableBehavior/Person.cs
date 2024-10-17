namespace sessionFive.App.ObservableBehavior;

public class Person
{
    public Person(string name)
    {
        Name = name;
        Sanitize();
    }
    
    private string Name { get; set; }

    private void Sanitize()
    {
        Name = Name.Replace("&","");
    }
}

