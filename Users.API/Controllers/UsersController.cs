using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.API.Commands.CreateUser;
using Users.API.Queries;

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

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync(CancellationToken ct) =>
        Ok(await _sender.Send(new GetAllUsersQuery(), ct));

    [HttpPost("CreateUser")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserCommand command, CancellationToken ct) => 
        Ok(await _sender.Send(command, ct));
}
