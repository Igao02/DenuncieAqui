using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentContent { get; set; }

        public int? CommentCount { get; set; }

        public DateTime? CommentDate { get; set; } = DateTime.Now;

        public Report Report { get; set; }

        public Comment(int commentId, string commentContent, int? commentCount, DateTime? commentDate)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            CommentCount = commentCount;
            CommentDate = commentDate;
            
        }
    }
}
