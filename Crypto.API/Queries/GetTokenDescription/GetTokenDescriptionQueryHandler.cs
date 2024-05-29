using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetTokenDescription;

public sealed class GetTokenDescriptionQueryHandler : IRequestHandler<GetTokenDescriptionQuery, TokenDescriptionDto>
{
    private readonly ICoinGeckoService _coinGeckoService;

    public GetTokenDescriptionQueryHandler(ICoinGeckoService cryptoService)
    {
        _coinGeckoService = cryptoService;
    }

    public Task<TokenDescriptionDto> Handle(GetTokenDescriptionQuery request, CancellationToken cancellationToken)
    {
        return _coinGeckoService.GetTokenDescriptionAsync(request.tokenName, cancellationToken);
    }
}
