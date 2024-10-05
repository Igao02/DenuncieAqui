using DenuncieAqui.Application.ViewModels.Report;
using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;

namespace DenuncieAqui.Application.UseCases.ReportUseCase;

public class ReportUsecase
{
    private readonly IReportRepository _reportRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ApplicationDbContext _context;

    public ReportUsecase(IReportRepository reportRepository, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context)
    {
        _reportRepository = reportRepository;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
    }

    public async Task<IEnumerable<ReportViewModel>> GetReportsAsync()
    {
        var reports = await _reportRepository.GetListAsync();

        var result = reports.Select(x => new ReportViewModel()
        {
            Id = x.Id,
            ReportDescription = x.ReportDescription,
            ReportName = x.ReportName,
            ReportsDate = x.ReportsDate,
            UserName = x.UserName,
            Comments = x.Comments,
            Images = x.Images,
            Likes = x.Likes,
            TypeReport = x.TypeReport,
            IsEditing = false
        }).ToList();

        return result;
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

        if (user.IsInRole("ADMIN") || report.UserName == userName)
        {
            await _reportRepository.DeleteAsync(reportId);
        }
        else
        {
            throw new UnauthorizedAccessException("Usuário não tem permissão para deletar este relatório.");
        }

    }

    public async Task<Report> UpdateReportAsync(ReportViewModel report)
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
