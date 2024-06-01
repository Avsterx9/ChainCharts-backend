using Crypto.API.Models.Database;
using Crypto.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crypto.API.Repositories;

public class CryptoRepository : ICryptoRepository
{
    private readonly CryptoContext _context;

    public CryptoRepository(CryptoContext context)
    {
        _context = context;
    }

    public async Task<List<FavouriteToken>> GetFavouriteTokensAsync(Guid userId, CancellationToken ct)
    {
        return await _context.FavouriteTokens
            .Where(x => x.UserId == userId)
            .ToListAsync(ct);
    }

    public async Task<FavouriteToken> AddFavouriteTokenAsync(FavouriteToken token, CancellationToken ct)
    {
        await _context.FavouriteTokens.AddAsync(token);
        await _context.SaveChangesAsync(ct);
        return token;
    }

    public async Task DeleteFavouriteToken(FavouriteToken token, CancellationToken ct)
    {
        _context.FavouriteTokens.Remove(token);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<FavouriteToken?> GetFavouriteTokenById(string TokenId, CancellationToken ct)
    {
        return await _context.FavouriteTokens.FirstOrDefaultAsync(x => x.TokenId == TokenId, ct);
    }

    public async Task<UserToken> AddUserTokenAsync(UserToken token, CancellationToken ct)
    {
        await _context.UserTokens.AddAsync(token);
        await _context.SaveChangesAsync(ct);
        return token;
    }

    public async Task<List<UserToken>> GetUserTokensAsync(Guid userId, CancellationToken ct)
    {
        return await _context.UserTokens
            .Where(x => x.UserId == userId)
            .ToListAsync(ct);
    }

    public async Task DeleteUserToken(UserToken token, CancellationToken ct)
    {
        _context.UserTokens.Remove(token);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<UserToken?> GetUserTokenById(string TokenId, CancellationToken ct)
    {
        return await _context.UserTokens.FirstOrDefaultAsync(x => x.TokenId == TokenId, ct);
    }
}
