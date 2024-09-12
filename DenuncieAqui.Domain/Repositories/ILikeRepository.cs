using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface ILikeRepository
{
    Task<Like?> GetAsync(Guid id);

    Task<IEnumerable<Like>> GetLikesAsync();

    Task <Like> AddLikesAsync(Like like);

    Task RemoveLikesAsync(Guid id);
}
