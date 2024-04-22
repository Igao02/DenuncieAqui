using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Reports
    {
        [Key]
        public int ReportsId { get; set; }

        public string ReportsName { get; set; }

        public string TypeReport {  get; set; }

        public string? ReportsDescription { get; set; }
        
        public DateTime ReportsDate { get; set; }

        public Reports(int reportsId, string reportsName, string typeReport, string? reportsDescription, DateTime reportsDate)
        {
            ReportsId = reportsId;
            ReportsName = reportsName;
            TypeReport = typeReport;
            ReportsDescription = reportsDescription;
            ReportsDate = reportsDate;
        }
    }
}
