using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetPriceData;

public sealed class GetPriceDataQueryHandler : IRequestHandler<GetPriceDataQuery, PriceDataDto>
{
    private readonly ICryptoService _cryptoService;

    public GetPriceDataQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<PriceDataDto> Handle(GetPriceDataQuery request, CancellationToken cancellationToken)
    {
        return await _cryptoService.GetPriceDataAsync(request.TokenName, request.Days, cancellationToken);
    }
}
