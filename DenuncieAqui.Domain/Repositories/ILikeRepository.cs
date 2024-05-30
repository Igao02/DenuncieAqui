using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface ILikeRepository
{
    Task<IEnumerable<Like>> GetLikesAsync();

    Task <Like> AddLikesAsync(Like likes);

    Task RemoveLikesAsync(int id);
}
