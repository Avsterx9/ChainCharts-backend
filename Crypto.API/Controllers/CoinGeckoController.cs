using Crypto.API.Queries.GetCGTokens;
using Crypto.API.Queries.GetPriceData;
using Crypto.API.Queries.GetTokenDescription;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.API.Controllers;

[Route("api/crypto")]
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
    public async Task<IActionResult> GetPriceData([FromQuery] string TokenName,[FromQuery] int Days, CancellationToken ct) =>
        Ok(await _sender.Send(new GetPriceDataQuery(TokenName, Days), ct));

    [HttpGet("GetTokenDescription")]
    public async Task<IActionResult> GetTokenDescription([FromQuery] string TokenName, CancellationToken ct) =>
        Ok(await _sender.Send(new GetTokenDescriptionQuery(TokenName), ct));
}
