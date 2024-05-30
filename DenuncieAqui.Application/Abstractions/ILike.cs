using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface ILike
    {
        Task<IEnumerable<Like>> GetLikesAsync();

        Task <Like> AddLikesAsync(Like likes);

        Task RemoveLikesAsync(int id);
    }
}
