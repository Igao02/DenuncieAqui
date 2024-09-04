using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetListAsync();

    Task<Comment?> GetAsync(Guid id);

    Task<Comment> AddAsync(Comment comment);

    Task DeleteAsync(Guid id);

    Task<Comment> EditAsync(Comment comment);

    Task<int> SumCommentAsync(Guid id);
}
