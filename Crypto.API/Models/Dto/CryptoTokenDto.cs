namespace Crypto.API.Models.Dto;

public record CryptoTokenDto
{
    public string Id { get; set; } = string.Empty!;
    public string Symbol { get; set; } = string.Empty!;
    public string Name { get; set; } = string.Empty!;
    public string Image { get; set; } = string.Empty!;
    public decimal CurrentPrice { get; set; }
    public long MarketCap { get; set; }
    public int MarketCapRank { get; set; }
    public long? FullyDilutedValuation { get; set; }
    public long TotalVolume { get; set; }
    public decimal High24h { get; set; }
    public decimal Low24h { get; set; }
    public decimal PriceChange24h { get; set; }
    public decimal PriceChangePercentage24h { get; set; }
    public long MarketCapChange24h { get; set; }
    public decimal MarketCapChangePercentage24h { get; set; }
    public decimal CirculatingSupply { get; set; }
    public decimal? TotalSupply { get; set; }
    public decimal? MaxSupply { get; set; }
    public decimal Ath { get; set; }
    public decimal AthChangePercentage { get; set; }
    public DateTime AthDate { get; set; }
    public decimal Atl { get; set; }
    public decimal AtlChangePercentage { get; set; }
    public DateTime AtlDate { get; set; }
    public object Roi { get; set; }
    public DateTime LastUpdated { get; set; }
}
