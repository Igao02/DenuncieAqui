using DenuncieAqui.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Entities
{
    public class LivroExemplo
    {

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
