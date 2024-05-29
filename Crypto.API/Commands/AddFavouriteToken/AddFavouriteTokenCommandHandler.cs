using Crypto.API.Models.Responses;
using Crypto.API.Services;
using MediatR;

namespace Crypto.API.Commands.AddFavouriteToken;

public sealed class AddFavouriteTokenCommandHandler : IRequestHandler<AddFavouriteTokenCommand, StandardResponse>
{
    private readonly ICryptoService _cryptoService;

    public AddFavouriteTokenCommandHandler(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<StandardResponse> Handle(AddFavouriteTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await _cryptoService.AddFavouriteTokenAsync(request.TokenName, cancellationToken);

        if (token is false)
            return new StandardResponse(false, "Could not add favourite token");

        return new StandardResponse(true, "Token added successfully");
    }
}
