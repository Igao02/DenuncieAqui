using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;

namespace DenuncieAqui.Application.UseCases.ReportUseCase;

public class ReportUsecase
{
    private readonly IReportRepository _reportRepository;

    public ReportUsecase(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> GetReportsAsync()
    {
        var reports = await _reportRepository.GetListAsync();

        return reports;
    }

    public async Task<Report?> GetAsync(Guid id)
    {
        var report = await _reportRepository.GetAsync(id);

        return report;
    }

    public async Task<Report> CreateReportAsync(Report report)
    {
        var createdReport = await _reportRepository.AddAsync(report);
        return createdReport;
    }

    public async Task DeleteReportAsync(Guid id)
    {
        await _reportRepository.DeleteAsync(id);
    }

    public async Task<Report> UpdateReportAsync(Report report)
    {
        var updateReport = await _reportRepository.EditAsync(report);
        return updateReport;
    }
}
