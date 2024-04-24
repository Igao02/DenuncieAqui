﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Likes
    {
        [Key]
        public int LikeId { get; set; }

        public DateTime? LikeDate { get; set; } = DateTime.Now;

        public Reports Reports { get; set; }

        public Likes(int likeId, DateTime? likeDate)
        {
            LikeId = likeId;
            LikeDate = likeDate;
            
        }
    }
}
