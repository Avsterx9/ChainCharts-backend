using Microsoft.EntityFrameworkCore;

namespace Users.API.Models.Database;

public sealed class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : base( options )
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity
    }

}
