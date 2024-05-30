using DenuncieAqui.CrossCutting.Entities;

namespace DenuncieAqui.Domain.Entities;

/// <summary>
/// Denuncia (Entidade)
/// </summary>
public class Report : Entity
{
    public Report()
    {
        /* ORM purpose */
    }

    public string ReportName { get; protected set; }

    public string? TypeReport {  get; set; }

    public string? ReportDescription { get; set; }

    public DateTime ReportsDate { get; set; } = DateTime.Now;

    public virtual List<Comment> Comments { get; set; } = new List<Comment>();

    public virtual List<Like> Likes { get; set; } = new List<Like>();

    public virtual List<Image> Images { get; set; } = new List<Image>();

    /*public Report(string reportsName, string? typeReport, string? reportsDescription, DateTime reportsDate) : base()
    {
        ReportName = reportsName;
        TypeReport = typeReport;
        ReportDescription = reportsDescription;
        ReportsDate = reportsDate;
    }*/

    public void SetReportName(string reportName)
    {
        ReportName = reportName;
    }
}
