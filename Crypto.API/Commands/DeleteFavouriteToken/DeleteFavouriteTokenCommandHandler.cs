using Crypto.API.Models.Responses;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Commands.DeleteFavouriteToken;

public sealed class DeleteFavouriteTokenCommandHandler : IRequestHandler<DeleteFavouriteTokenCommand, StandardResponse>
{
    private readonly ICryptoService _cryptoService;

    public DeleteFavouriteTokenCommandHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<StandardResponse> Handle(DeleteFavouriteTokenCommand request, CancellationToken cancellationToken)
    {
        var deleteStatus = await _cryptoService.DeleteFavouriteTokenAsync(request.TokenId, cancellationToken);

        if (deleteStatus is false)
            return new StandardResponse(false, "Could not remove favourite token");

        return new StandardResponse(true, "Token removed successfully");
    }
}
