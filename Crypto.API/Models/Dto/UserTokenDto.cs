namespace Crypto.API.Models.Dto;

public class UserTokenDto
{
    public string TokenId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public string Symbol { get; set; }
    public decimal Quantity { get; set; }
    public decimal ValueEstimation { get; set; }
}
