using DenuncieAqui.DomainCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenuncieAqui.Domain.Entities;

public class Image : Entity
{
    public string ImageName { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public virtual Guid ReportId { get; set; }

    public virtual Report Report { get; set; }

    /*public Image(string? imageName, string imageUrl, string? imageContent) : base()
    {
        ImageName = imageName;
        ImageUrl = imageUrl;
        ImageContent = imageContent;
    }*/
}
