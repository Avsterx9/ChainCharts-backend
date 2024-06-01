using Crypto.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crypto.API.Models.Database;

public class CryptoContext : DbContext
{
    public DbSet<FavouriteToken> FavouriteTokens { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

    public CryptoContext(DbContextOptions<CryptoContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavouriteToken>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.ToTable("favourite_tokens");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.ToTable("user_tokens");
        });
    }
}
