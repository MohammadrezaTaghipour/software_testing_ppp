using System.Text.Json.Serialization;

namespace sessionTen.App.Application;

public class ChangeUserEmailRequest
{
    [JsonIgnore] public int Id { get; set; }
    public string NewEmail { get; set; }
}