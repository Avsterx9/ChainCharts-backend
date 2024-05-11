using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetGlobalData;

public sealed class GetGlobalDataQueryHandler : IRequestHandler<GetGlobalDataQuery, GlobalDataDto>
{
    private readonly ICryptoService _cryptoService;

    public GetGlobalDataQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<GlobalDataDto> Handle(GetGlobalDataQuery request, CancellationToken cancellationToken)
    {
        return await _cryptoService.GetGlobalDataAsync(cancellationToken);
    }
}
