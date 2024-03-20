namespace Api.Models;

public class AuthenticModel : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime? DateCreation { get; set; }
}