using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.API.Commands.CreateUser;
using Users.API.Commands.Login;
using Users.API.Models.Dto.Auth;
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
    public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsDto credentialsDto, CancellationToken ct) =>
        Ok(await _sender.Send(new LoginCommand(credentialsDto), ct));

    [Authorize]
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync(CancellationToken ct) =>
        Ok(await _sender.Send(new GetAllUsersQuery(), ct));

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserRegistrationDto registrationDto, CancellationToken ct) => 
        Ok(await _sender.Send(new CreateUserCommand(registrationDto), ct));

    [Authorize]
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserByIdAsync([FromQuery] Guid Id, CancellationToken ct) =>
        Ok(await _sender.Send(new GetUserByIdQuery(Id), ct));
}
