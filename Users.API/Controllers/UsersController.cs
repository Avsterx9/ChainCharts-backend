using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.API.Queries;

namespace Users.API.Controllers;

public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers() => Ok(await _sender.Send(new GetAllUsersQuery()));
}
