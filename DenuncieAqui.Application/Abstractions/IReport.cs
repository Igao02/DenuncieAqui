using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface IReport
    {
        Task <IEnumerable<Report>> GetReportsAsync();

        Task <Report> GetReportAsync (int id);

        Task <Report?> AddReportsAsync(Report reports);

        Task  RemoveReportsAsync(int id);

        Task  EditReportsAsync(Report reports);


    }
}
