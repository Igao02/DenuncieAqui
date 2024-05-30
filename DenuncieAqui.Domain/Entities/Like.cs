using DenuncieAqui.CrossCutting.Entities;

namespace DenuncieAqui.Domain.Entities;

public class Like : Entity
{
    public DateTime? LikeDate { get; set; } = DateTime.Now;

    public Guid ReportId { get; set; }

    public virtual Report Report { get; set; }

    /*public Like(DateTime? likeDate, int? likeCount) : base()
    {
        LikeDate = likeDate;
        LikeCount = likeCount;
    }*/
}
