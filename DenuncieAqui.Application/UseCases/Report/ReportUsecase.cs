﻿using DenuncieAqui.Application.ViewModels.Report;
using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;


namespace DenuncieAqui.Application.UseCases.ReportUseCase;

public class ReportUsecase
{
    private readonly IReportRepository _reportRepository;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReportUsecase(IReportRepository reportRepository, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _reportRepository = reportRepository;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
        _userManager = userManager;
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
            IsEditing = false,
            IsEvent = false,
        }).OrderByDescending(r => r.ReportsDate).ToList();

        return result;
    }

    public async Task<Report?> GetAsync(Guid id)
    {
        var report = await _reportRepository.GetAsync(id);

        return report;
    }

    public async Task<Report> CreateReportAsync(Report report)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado");
        }

        var userName = user.Identity.Name;
        report.UserName = userName;

        if (report.UserName == null)
        {
            throw new UnauthorizedAccessException("Nome de usuário nulo");
        }

        if (user.IsInRole("PARTNER"))
        {
            report.IsEvent = report.TypeReport == "Evento";
        }
        else
        {
            report.IsEvent = false;
        }

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

    public async Task<IEnumerable<ReportViewModel>> GetUserReportsAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }

        var userName = user.Identity.Name;

        if (string.IsNullOrEmpty(userName))
        {
            throw new UnauthorizedAccessException("Nome de usuário não encontrado.");
        }

        var userReports = await _reportRepository.GetListAsync();
        userReports = userReports.Where(x => x.UserName == userName).ToList();

        var result = userReports.Select(x => new ReportViewModel()
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
            IsEditing = false,
            IsEvent = false,
        }).OrderByDescending(r => r.ReportsDate).ToList();

        return result;
    }

    public async Task<IEnumerable<ReportViewModel>> GetReportsByTypeAsync(string type)
    {
        var reports = await _reportRepository.GetReportsByTypeAsync(type);
        return reports.Select(report => new ReportViewModel
        {
            Id = report.Id,
            ReportName = report.ReportName,
            TypeReport = report.TypeReport,
            ReportDescription = report.ReportDescription,
            Images = report.Images,
            Comments = report.Comments,
            Likes = report.Likes,
            UserName = report.UserName,
            IsEditing = false
        });
    }

    public async Task<Dictionary<string, bool>> GetPartnersStatusAsync(IEnumerable<string> userNames)
    {
        var userStatuses = new Dictionary<string, bool>();

        foreach (var userName in userNames.Distinct()) 
        {
            var user = await _userManager.FindByNameAsync(userName); 
            userStatuses[userName] = user != null && await _userManager.IsInRoleAsync(user, "PARTNER");
        }

        return userStatuses; 
    }
}

