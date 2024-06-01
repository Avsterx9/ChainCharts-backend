namespace Crypto.API.Models.Entities;

public class UserToken
{
    public Guid Id { get; set; }
    public string TokenId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal Quantity { get; set; }
}
