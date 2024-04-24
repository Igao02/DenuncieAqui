using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Images
    {
        [Key]
        public int ImagesId { get; set; }

        public string? ImageName { get; set; }

        public string ImageUrl { get; set; } 

        public string? ImageContent {  get; set; }

        public Reports Reports { get; set; }

        public Images(int imagesId, string? imageName, string imageUrl, string? imageContent)
        {
            ImagesId = imagesId;
            ImageName = imageName;
            ImageUrl = imageUrl;
            ImageContent = imageContent;
        }
    }
}
