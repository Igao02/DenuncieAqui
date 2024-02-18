using DenuncieAqui.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DenuncieAqui.Domain.Entities
{
    public class LivroExemplo
    {
        [Key]
        public int LivroId { get; set; }
        public string LivroName { get; set; }
        public string? Cover {  get; set; }
        public PublishCompany PublishCompany{ get; set; }
        public Category Category { get; set; }

        public LivroExemplo(int livroId, string livroName, string? cover, PublishCompany publishCompany, Category category)
        {
            LivroId = livroId;
            LivroName = livroName;
            Cover = cover;
            PublishCompany = publishCompany;
            Category = category;
        }


    }
}
