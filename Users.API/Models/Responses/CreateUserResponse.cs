namespace Users.API.Models.Responses;

public record CreateUserResponse : StandardResponse
{
    public Guid Id { get; set; }
}
