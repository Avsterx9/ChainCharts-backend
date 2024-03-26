using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Common.Services;
public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var user = _httpContextAccessor.HttpContext.User;

        if (user is null)
            throw new KeyNotFoundException("User id not found");

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
            throw new KeyNotFoundException("User id not found");

        return new Guid(userId);
    }
}
