using Microsoft.EntityFrameworkCore;
using Users.API.Models.Entities;
using Users.API.Models.Enums;

namespace Users.API.Models.Database;

public sealed class UsersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public UsersContext(DbContextOptions<UsersContext> options) : base( options )
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasData(new Role
            {
                Id = (int)RoleType.Trainer,
                Name = "Trener"
            });

            entity.HasData(new Role
            {
                Id = (int)RoleType.Client,
                Name = "Podopieczny"
            });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);
        });
    }

}
