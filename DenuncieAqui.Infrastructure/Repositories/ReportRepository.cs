﻿using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly ApplicationDbContext _context;

    public ReportRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Report>> GetListAsync() => await _context.Reports.ToListAsync();

    public async Task<Report?> GetAsync(Guid id) => await _context.Reports.FindAsync(id);

    public async Task<Report> AddAsync(Report report)
    {
        await _context.AddAsync(report);

        await _context.SaveChangesAsync(); 

        return report;
    }

    public async Task DeleteAsync(Guid id)
    {
        var report = await GetAsync(id);

        _context.Reports.Remove(report!);
    }

    public async Task<Report> EditAsync(Report report)
    {
        _context.Entry(report).State = EntityState.Modified;

        return report;
    }
}
