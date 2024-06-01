using Crypto.API.Commands.AddFavouriteToken;
using Crypto.API.Commands.AddUserToken;
using Crypto.API.Commands.DeleteFavouriteToken;
using Crypto.API.Commands.DeleteUserToken;
using Crypto.API.Models.Dto;
using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Queries.GetFavouriteTokens;
using Crypto.API.Queries.GetUserTokens;
using Crypto.API.Queries.GetWalletEstimation;
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

    [HttpPost("AddFavouriteToken")]
    public async Task<IActionResult> AddFavouriteToken([FromQuery] string TokenId, CancellationToken ct) =>
        Ok(await _sender.Send(new AddFavouriteTokenCommand(TokenId), ct));

    [HttpGet("GetFavouriteTokens")]
    public async Task<IActionResult> GetFavouriteTokens(CancellationToken ct) =>
        Ok(await _sender.Send(new GetFavouriteTokensQuery(), ct));

    [HttpDelete("DeleteFavouriteToken")]
    public async Task<IActionResult> DeleteFavouriteToken([FromQuery] string TokenId, CancellationToken ct) =>
        Ok(await _sender.Send(new DeleteFavouriteTokenCommand(TokenId), ct));

    [HttpPost("AddUserToken")]
    public async Task<IActionResult> AddUserToken([FromBody] UserTokenLiteDto model, CancellationToken ct) =>
        Ok(await _sender.Send(new AddUserTokenCommand(model), ct));

    [HttpGet("GetUserTokens")]
    public async Task<IActionResult> GetUserTokens(CancellationToken ct) =>
        Ok(await _sender.Send(new GetUserTokensQuery(), ct));

    [HttpDelete("DeleteUserToken")]
    public async Task<IActionResult> DeleteUserToken([FromQuery] string TokenId, CancellationToken ct) =>
        Ok(await _sender.Send(new DeleteUserTokenCommand(TokenId), ct));

    [HttpGet("Wallet")]
    public async Task<IActionResult> GetWalletEstimation(CancellationToken ct) =>
        Ok(await _sender.Send(new GetWalletEstimationQuery(), ct));
}
