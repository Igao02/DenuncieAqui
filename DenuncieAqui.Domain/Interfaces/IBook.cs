using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Domain.Interfaces
{
    public interface IBook
    {
        Task<IEnumerable<Book>> ObterLivros();
        Task<IBook?> AdicionarLivro(Book book);
        Task<IBook> DeletarLivro(int id);

    }
}