﻿using DenuncieAqui.DomainCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenuncieAqui.Domain.Entities;

public class Comment : Entity
{
    public Comment()
    {

    }

    public string CommentContent { get; set; }

    public DateTime CommentDate { get; set; } = DateTime.Now;

    public virtual Guid ReportId { get; set; }

    public virtual Report Report { get; set; }

    /*public Comment(string commentContent, int commentCount, DateTime commentDate) : base()
    {
        CommentContent = commentContent;
        CommentCount = commentCount;
        CommentDate = commentDate;
    }*/
}
