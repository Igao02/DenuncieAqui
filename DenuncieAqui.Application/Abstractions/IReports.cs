using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface IReports
    {
        Task <IEnumerable<Reports>> GetReportsAsync();

        Task <Reports> GetReportAsync (int id);

        Task <Reports?> AddReportsAsync(Reports reports);

        Task  RemoveReportsAsync(int id);

        Task  EditReportsAsync(int id);

        Task SumCommentsAsync (int id);
    }
}
