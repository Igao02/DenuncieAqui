using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Interfaces;
using DenuncieAqui.Infrastructure.Data;

namespace DenuncieAqui.Infrastructure.Repositories
{
    public class BookRepository : IBook

    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IBook?> AdicionarLivro(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return (IBook?)book;
        }

        public Task<IBook> DeletarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IBook>> ObterLivros()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IBook.ObterLivros()
        {
            throw new NotImplementedException();
        }
    }
}