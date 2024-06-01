namespace Crypto.API.Models.Dto;

public record UserTokenLiteDto
{
    public string TokenId { get; set; }
    public decimal Quantity { get; set; }
}
