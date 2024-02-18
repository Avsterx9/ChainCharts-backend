namespace Users.API.Models.Responses;

public record StandardResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}
