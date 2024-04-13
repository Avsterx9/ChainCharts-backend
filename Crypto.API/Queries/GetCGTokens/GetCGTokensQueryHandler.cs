using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetCGTokens;

public sealed class GetCGTokensQueryHandler : IRequestHandler<GetCGTokensQuery, IEnumerable<CryptoTokenDto>>
{
    private readonly ICryptoService _cryptoService;

    public GetCGTokensQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<IEnumerable<CryptoTokenDto>> Handle(GetCGTokensQuery request, CancellationToken cancellationToken)
    {
        return await _cryptoService.GetCGTokensAsync(request);
    }
}
