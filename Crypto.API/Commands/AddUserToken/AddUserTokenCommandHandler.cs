using Crypto.API.Models.Responses;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Commands.AddUserToken;

public sealed class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommand, StandardResponse>
{
    private readonly ICryptoService _cryptoService;

    public AddUserTokenCommandHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<StandardResponse> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await _cryptoService.AddUserTokenAsync(request.model, cancellationToken);

        if (token is false)
            return new StandardResponse(false, "Could not add user token");

        return new StandardResponse(true, "Token added successfully");
    }
}
