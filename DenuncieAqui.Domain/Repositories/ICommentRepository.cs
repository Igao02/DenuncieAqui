using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetListAsync();

    Task<Comment> AddAsync(Comment comments);

    Task DeleteAsync(int id);

    Task EditAsync(int id);

    Task<int> SumCommentAsync(int id);
}
