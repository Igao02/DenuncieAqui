using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentContent { get; set; }

        public int? CommentCount { get; set; }

        public DateTime? CommentDate { get; set; } = DateTime.Now;

        public Reports Reports { get; set; }

        public Comments(int commentId, string commentContent, int? commentCount, DateTime? commentDate)
        {
            CommentId = commentId;
            CommentContent = commentContent;
            CommentCount = commentCount;
            CommentDate = commentDate;
            
        }
    }
}
