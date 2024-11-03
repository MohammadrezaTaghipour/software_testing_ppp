using System.Text.Json.Serialization;

namespace sessionNine.App.Application;

public class ChangeUserEmailRequest
{
    [JsonIgnore] public int Id { get; set; }
    public string NewEmail { get; set; }
}