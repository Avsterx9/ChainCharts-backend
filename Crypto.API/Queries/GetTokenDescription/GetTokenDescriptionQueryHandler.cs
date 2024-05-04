using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetTokenDescription;

public sealed class GetTokenDescriptionQueryHandler : IRequestHandler<GetTokenDescriptionQuery, TokenDescriptionDto>
{
    private readonly ICryptoService _cryptoService;

    public GetTokenDescriptionQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public Task<TokenDescriptionDto> Handle(GetTokenDescriptionQuery request, CancellationToken cancellationToken)
    {
        return _cryptoService.GetTokenDescriptionAsync(request.tokenName, cancellationToken);
    }
}
