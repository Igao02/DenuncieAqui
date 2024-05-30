using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string? ImageName { get; set; }

        public string ImageUrl { get; set; }

        public string? ImageContent {  get; set; }

        public Report Report { get; set; }

        public Image(int imagesId, string? imageName, string imageUrl, string? imageContent)
        {
            ImageId = imagesId;
            ImageName = imageName;
            ImageUrl = imageUrl;
            ImageContent = imageContent;
        }
    }
}
