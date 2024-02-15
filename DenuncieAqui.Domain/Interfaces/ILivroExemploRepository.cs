using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Interfaces
{
    public interface ILivroExemploRepository
    {
        Task<IEnumerable<LivroExemplo>> ObterLivros();
        Task<LivroExemplo?> AdicionarLivro(LivroExemplo livroExemplo);
        Task<LivroExemplo> DeletarLivro(int id);
        
    }
}
