namespace Users.API.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
