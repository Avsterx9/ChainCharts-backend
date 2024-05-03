using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Queries.GetPriceData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.API.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class CoinGeckoController : ControllerBase
{
    private readonly ISender _sender;

    public CoinGeckoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetTokens")]
    public async Task<IActionResult> GetTokens(CancellationToken ct) =>
        Ok(await _sender.Send(new GetCGTokensQuery(), ct));


    [HttpGet("GetPriceData")]
    public async Task<IActionResult> GetTokens([FromQuery] string TokenName,[FromQuery] int Days, CancellationToken ct) =>
        Ok(await _sender.Send(new GetPriceDataQuery(TokenName, Days), ct));
}
