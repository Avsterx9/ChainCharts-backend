namespace Crypto.API.Models.Dto;

public record UserTokenLiteDto
{
    public string TokenId { get; set; }
    public int Quantity { get; set; }
}
