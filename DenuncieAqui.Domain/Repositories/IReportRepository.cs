using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> GetListAsync();

    Task<IEnumerable<Report>> GetReportsByTypeAsync(string type);

    Task<Report?> GetAsync(Guid id);

    Task<Report> AddAsync(Report report);

    Task<Report> EditAsync(Report report);

    Task DeleteAsync(Guid id);

}