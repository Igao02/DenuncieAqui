using DenuncieAqui.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DenuncieAqui.Domain.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string? Cover { get; set; }
        public int ? BookNumber { get; set; }
        public PublishCompany PublishCompany { get; set; }
        public Category Category { get; set; }

        public Book(int bookId, string bookName, int? bookNumber, string? cover, PublishCompany publishCompany, Category category)
        {
            BookId = bookId;
            BookName = bookName;
            BookNumber = bookNumber;
            Cover = cover;
            PublishCompany = publishCompany;
            Category = category;
        }


    }
}