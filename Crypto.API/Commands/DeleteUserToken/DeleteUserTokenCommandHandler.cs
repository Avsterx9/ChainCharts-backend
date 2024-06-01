using Crypto.API.Models.Responses;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Commands.DeleteUserToken;

public sealed class DeleteUserTokenCommandHandler : IRequestHandler<DeleteUserTokenCommand, StandardResponse>
{
    private readonly ICryptoService _cryptoService;

    public DeleteUserTokenCommandHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<StandardResponse> Handle(DeleteUserTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _cryptoService.DeleteUserTokenAsync(request.TokenId, cancellationToken);

        if (result is false)
            return new StandardResponse(false, "Could not remove token");

        return new StandardResponse(true, "Token removed successfully");
    }
}
