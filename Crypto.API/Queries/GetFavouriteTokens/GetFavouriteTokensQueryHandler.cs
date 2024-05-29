using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetFavouriteTokens;

public sealed class GetFavouriteTokensQueryHandler : IRequestHandler<GetFavouriteTokensQuery, IEnumerable<FavouriteTokenDto>>
{
    private readonly ICryptoService _cryptoService;

    public GetFavouriteTokensQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<IEnumerable<FavouriteTokenDto>> Handle(GetFavouriteTokensQuery request, CancellationToken cancellationToken)
    {
        return await _cryptoService.GetFavouriteTokensAsync(cancellationToken);
    }
}
