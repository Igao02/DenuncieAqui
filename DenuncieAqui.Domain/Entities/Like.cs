using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public DateTime? LikeDate { get; set; } = DateTime.Now;

        public int? LikeCount { get; set; }

        public Report Report { get; set; }

        public Like(int likeId, DateTime? likeDate, int? likeCount)
        {
            LikeId = likeId;
            LikeDate = likeDate;
            LikeCount = likeCount;
        }
    }
}
