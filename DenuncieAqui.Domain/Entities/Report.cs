using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public string ReportsName { get; set; }

        public string? TypeReport {  get; set; }

        public string? ReportsDescription { get; set; }

        public DateTime ReportsDate { get; set; } = DateTime.Now;

        public List<Comment> Coments { get; set; } = new List<Comment>();

        public List<Like> Likes { get; set; } = new List<Like>();

        public List<Image> Images { get; set; } = new List<Image>();

        public Report(int reportsId, string reportsName, string? typeReport, string? reportsDescription, DateTime reportsDate)
        {
            ReportId = reportsId;
            ReportsName = reportsName;
            TypeReport = typeReport;
            ReportsDescription = reportsDescription;
            ReportsDate = reportsDate;
            
        }
    }
}
