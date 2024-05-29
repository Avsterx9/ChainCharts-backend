using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetGlobalData;

public sealed class GetGlobalDataQueryHandler : IRequestHandler<GetGlobalDataQuery, GlobalDataDto>
{
    private readonly ICoinGeckoService _coinGeckoService;

    public GetGlobalDataQueryHandler(ICoinGeckoService cryptoService)
    {
        _coinGeckoService = cryptoService;
    }

    public async Task<GlobalDataDto> Handle(GetGlobalDataQuery request, CancellationToken cancellationToken)
    {
        return await _coinGeckoService.GetGlobalDataAsync(cancellationToken);
    }
}
