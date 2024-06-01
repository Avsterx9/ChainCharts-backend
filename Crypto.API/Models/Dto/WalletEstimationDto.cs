namespace Crypto.API.Models.Dto;

public record WalletEstimationDto
{
    public decimal TotalEstimation { get; set; }
    public List<TokenValueDto> TokenValues{get;set;}
}

public record TokenValueDto
{
    public string Name { get; set; }
    public decimal Value { get; set; }
}