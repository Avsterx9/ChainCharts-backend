namespace Users.API.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
