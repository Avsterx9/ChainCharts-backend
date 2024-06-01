using Crypto.API.Commands.AddFavouriteToken;
using Crypto.API.Commands.DeleteFavouriteToken;
using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Queries.GetFavouriteTokens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Crypto.API.Controllers;

[Route("api/crypto")]
[ApiController]
[Authorize]
public class TokenController : ControllerBase
{
    private readonly ISender _sender;

    public TokenController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("AddFavourite")]
    public async Task<IActionResult> AddFavouriteToken([FromQuery] string TokenId, CancellationToken ct) =>
        Ok(await _sender.Send(new AddFavouriteTokenCommand(TokenId), ct));

    [HttpGet("GetFavouriteTokens")]
    public async Task<IActionResult> GetFavouriteTokens(CancellationToken ct) =>
        Ok(await _sender.Send(new GetFavouriteTokensQuery(), ct));

    [HttpDelete("DeleteFavouriteToken")]
    public async Task<IActionResult> DeleteFavouriteToken([FromQuery] string TokenId, CancellationToken ct) =>
        Ok(await _sender.Send(new DeleteFavouriteTokenCommand(TokenId), ct));
}
