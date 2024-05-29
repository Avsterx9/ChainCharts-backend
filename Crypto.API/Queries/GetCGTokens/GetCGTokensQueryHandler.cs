using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetCGTokens;

public sealed class GetCGTokensQueryHandler : IRequestHandler<GetCGTokensQuery, IEnumerable<CryptoTokenDto>>
{
    private readonly ICoinGeckoService _coinGeckoService;

    public GetCGTokensQueryHandler(ICoinGeckoService cryptoService)
    {
        _coinGeckoService = cryptoService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> Handle(GetCGTokensQuery request, CancellationToken cancellationToken)
    {
        return await _coinGeckoService.GetCGTokensAsync(request);
    }
}
