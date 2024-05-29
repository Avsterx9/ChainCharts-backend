using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetPriceData;

public sealed class GetPriceDataQueryHandler : IRequestHandler<GetPriceDataQuery, PriceDataDto>
{
    private readonly ICoinGeckoService _coinGeckoService;

    public GetPriceDataQueryHandler(ICoinGeckoService cryptoService)
    {
        _coinGeckoService = cryptoService;
    }

    public async Task<PriceDataDto> Handle(GetPriceDataQuery request, CancellationToken cancellationToken)
    {
        return await _coinGeckoService.GetPriceDataAsync(request.TokenName, request.Days, cancellationToken);
    }
}
