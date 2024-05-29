namespace Crypto.API.Models.Entities;

public class FavouriteToken
{
    public Guid Id { get; set; }
    public string TokenId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
}
