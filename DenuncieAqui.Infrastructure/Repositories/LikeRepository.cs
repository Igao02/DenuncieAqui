using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationDbContext _context;

    public LikeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Like?> GetAsync(Guid id) => await _context.Likes.FindAsync(id);

    public async Task<IEnumerable<Like>> GetLikesAsync() => await _context.Likes.ToListAsync();

    public async Task<Like> AddLikesAsync(Like like)
    {
        await _context.AddAsync(like);

        await _context.SaveChangesAsync();

        return like;
    }

    public async Task RemoveLikesAsync(Guid id)
    {
        var likes = await GetAsync(id);

        _context.Likes.Remove(likes!);

    }

}

