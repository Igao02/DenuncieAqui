using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Interfaces;
using DenuncieAqui.Infrastructure.Data;

namespace DenuncieAqui.Infrastructure.Repositories
{
    public class LivroExemploRepository : ILivroExemploRepository

    {
        private readonly ApplicationDbContext _context;

        public LivroExemploRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<LivroExemplo?> AdicionarLivro(LivroExemplo livroExemplo)
        {
            _context.LivroExemplos.Add(livroExemplo);
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
