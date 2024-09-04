using DenuncieAqui.DomainCore.Entities;

namespace DenuncieAqui.Domain.Entities;

public class Comment : Entity
{
    public Comment()
    {

    }

    public string CommentContent { get; set; }

    public DateTime CommentDate { get; set; } = DateTime.Now;

    //public int? CommentCount { get; set; }

    public virtual Guid ReportId { get; set; }

    public virtual Report Report { get; set; }

    public Comment(string commentContent, DateTime commentDate, Guid reportId) : base()
    {
        CommentContent = commentContent;
        CommentDate = commentDate;
        ReportId = reportId;
    }
}
