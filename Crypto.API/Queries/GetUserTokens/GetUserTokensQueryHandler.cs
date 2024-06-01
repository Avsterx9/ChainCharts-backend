using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetUserTokens;

public sealed class GetUserTokensQueryHandler : IRequestHandler<GetUserTokensQuery, IEnumerable<UserTokenDto>>
{
    private readonly ICryptoService _cryptoService;

    public GetUserTokensQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<IEnumerable<UserTokenDto>> Handle(GetUserTokensQuery request, CancellationToken cancellationToken)
    {
        return await _cryptoService.GetUserTokensAsync(cancellationToken);
    }
}
