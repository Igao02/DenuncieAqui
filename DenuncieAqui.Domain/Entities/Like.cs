using DenuncieAqui.DomainCore.Entities;

namespace DenuncieAqui.Domain.Entities;

public class Like : Entity
{
    public Like()
    {
        //Empty
    }

    public DateTime? LikeDate { get; set; } = DateTime.Now;

    public string UserName { get; set; }

    public virtual Guid ReportId { get; set; }

    public virtual Report Report { get; set; }

    public Like(DateTime? likeDate, string userName, Guid reportId) : base()
    {
        LikeDate = likeDate;
        UserName = userName;
        ReportId = reportId;
    }
}
