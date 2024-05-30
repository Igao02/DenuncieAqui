using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> GetListAsync();

    Task<Report?> GetAsync(Guid id);

    Task<Report> AddAsync(Report report);

    Task<Report> EditAsync(Report report);

    Task DeleteAsync(Guid id);

    Task SaveChangesAsync();
}
