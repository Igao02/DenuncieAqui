using DenuncieAqui.Blazor.Data;
using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Repositories
{
    internal class BookRepository : ILivroExemploRepository

    {
        private readonly ApplicationDbContext _context;
        
        public async Task<LivroExemplo?> AdicionarLivro(LivroExemplo livroExemplo)
        {
            _context.livroExemplos.Add(livroExemplo);
            await _context.SaveChangesAsync();
            return livroExemplo;
        }

        public Task<LivroExemplo> DeletarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LivroExemplo>> ObterLivros()
        {
            throw new NotImplementedException();
        }
    }
}
