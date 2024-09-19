using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Components.Authorization;

namespace DenuncieAqui.Application.UseCases.ReportUseCase;

public class ReportUsecase
{
    private readonly IReportRepository _reportRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public ReportUsecase(IReportRepository reportRepository, AuthenticationStateProvider authenticationStateProvider)
    {
        _reportRepository = reportRepository;
        _authenticationStateProvider = authenticationStateProvider;
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

    public async Task DeleteReportAsync(Guid reportId)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        var report = await _reportRepository.GetAsync(reportId);
        if (report.UserName != userName)
        {
            throw new UnauthorizedAccessException("Usuário não tem permissão para deletar este relatório.");
        }

        await _reportRepository.DeleteAsync(reportId);
    }


    public async Task<Report> UpdateReportAsync(Report report)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        var existingReport = await _reportRepository.GetAsync(report.Id);

        if (existingReport == null)
        {
            throw new Exception("Publicação não encontrada.");
        }

        if (existingReport.UserName != userName)
        {
            throw new UnauthorizedAccessException("Usuário não autorizado.");
        }

        existingReport.ReportName = report.ReportName;
        existingReport.ReportDescription = report.ReportDescription;
        existingReport.TypeReport = report.TypeReport; 
        existingReport.ReportsDate = DateTime.Now;

        var updateReport = await _reportRepository.EditAsync(existingReport);
        return updateReport;
    }

}
