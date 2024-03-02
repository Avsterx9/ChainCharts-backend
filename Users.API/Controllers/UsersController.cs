using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.API.Commands.CreateUser;
using Users.API.Commands.Login;
using Users.API.Queries.GetAllUsers;
using Users.API.Queries.GetUserById;

namespace Users.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromQuery] LoginCommand command, CancellationToken ct) =>
        Ok(await _sender.Send(command, ct));

    [Authorize]
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync(CancellationToken ct) =>
        Ok(await _sender.Send(new GetAllUsersQuery(), ct));

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command, CancellationToken ct) => 
        Ok(await _sender.Send(command, ct));

    [Authorize]
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserByIdAsync([FromQuery] GetUserByIdQuery query, CancellationToken ct) =>
        Ok(await _sender.Send(query, ct));
}
