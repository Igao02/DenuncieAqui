using DenuncieAqui.DomainCore.Entities;

namespace DenuncieAqui.Domain.Entities;

public class Image : Entity
{
    public Image() 
    {
        //Empty
    }

    public string ImageUrl { get; set; } = string.Empty;

    public DateTime ImageDate { get; set; }

    public virtual Guid ReportId { get; set; }

    public virtual Report? Report { get; set; }

    public Image(string imageUrl, DateTime imageDate, Guid reportId) : base()
    {
        ImageUrl = imageUrl;
        ImageDate = imageDate;
        ReportId = reportId;
    }
}
