namespace sessionFive.App.ObservableBehavior;

public class PersonService
{
    public void Create()
    {
        var person = new Person("&John Doe");
        
        //Save database
    }
    
    public void CreateV2()
    {
        var name = Sanitize("&John Doe");
        var person = new Person(name);
        
        
        //Save database
    }

    public string Sanitize(string value)
    {
        return value.Replace("&","");
    }
}