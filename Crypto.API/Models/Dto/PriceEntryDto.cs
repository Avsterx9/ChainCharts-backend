using Newtonsoft.Json;

namespace Crypto.API.Models.Dto;

public class PriceEntryDto
{
    //[JsonProperty("timestamp")]
    public double timestamp { get; set; }
    //[JsonProperty("price")]
    public double price { get; set; }
}
