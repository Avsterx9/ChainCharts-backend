using Crypto.API.Models.Dto;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Queries.GetWalletEstimation;

public sealed class GetWalletEstimationQueryHandler : IRequestHandler<GetWalletEstimationQuery, WalletEstimationDto>
{
    private readonly ICryptoService _cryptoService;

    public GetWalletEstimationQueryHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public Task<WalletEstimationDto> Handle(GetWalletEstimationQuery request, CancellationToken cancellationToken)
    {
        return _cryptoService.GetUserWalletEstimationAsync(cancellationToken);
    }
}
