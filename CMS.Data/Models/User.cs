namespace CMS.Data.Models;

public enum Role { manager, carer, family }
public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public Role Role { get; set; }

}
