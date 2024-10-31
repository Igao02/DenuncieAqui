using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Application.ViewModels.Report;

public class ReportViewModel
{
    public Guid Id { get; set; }
    public string ReportName { get; set; }

    public string TypeReport { get; set; }

    public string ReportDescription { get; set; }

    public string UserName { get; set; }

    public bool IsEvent { get; set; }

    public DateTime ReportsDate { get; set; } = DateTime.Now;
    public virtual List<Comment> Comments { get; set; } = new List<Comment>();

    public virtual List<Like> Likes { get; set; } = new List<Like>();

    public virtual List<Image> Images { get; set; } = new List<Image>();

    public bool IsEditing { get; set; }
}

