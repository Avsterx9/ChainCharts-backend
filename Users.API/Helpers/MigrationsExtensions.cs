using Microsoft.EntityFrameworkCore;
using Users.API.Models.Database;

namespace Users.API.Helpers;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using UsersContext usersContext = scope.ServiceProvider.GetService<UsersContext>();

        usersContext.Database.Migrate();
    }
}
