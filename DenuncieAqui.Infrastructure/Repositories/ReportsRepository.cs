using DenuncieAqui.Application.Abstractions;
using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Infrastructure.Repositories
{
    public class ReportsRepository : IReports
    {
        private readonly ApplicationDbContext _context;

        public ReportsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reports?> AddReportsAsync(Reports report)
        {
            _context.AddAsync(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task RemoveReportsAsync(int id)
        {
            var reports = await GetReportAsync(id);
            if (reports is not null)
            {
                _context.Reports.Remove(reports);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Não foi possivel excluir a denúncia existente!");
            }
        }

        public async Task EditReportsAsync(Reports report)
        {

            if (report is not null)
            {
                _context.Entry(report).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Não foi possivel atualizar a denúncia existente!");
            }
        }

        public async Task<Reports> GetReportAsync(int id)
        {

            var reports = await _context.Reports.FirstOrDefaultAsync(r => r.ReportsId == id);

            if (reports is null)
            {
                throw new InvalidOperationException($"Denúncia com o ID {id} não encontrado");
            }

            return reports;
        }

        public async Task<IEnumerable<Reports>> GetReportsAsync()
        {

            if ( _context is not null && _context.Reports is not null)
            {
                var reports = await _context.Reports.ToListAsync();
                return reports;
            }
            else
            {
                return new List<Reports>();
            }
        }

    }
}
