using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface ILikes
    {
        Task<IEnumerable<Likes>> GetLikesAsync();

        Task <Likes> AddLikesAsync(Likes likes);

        Task RemoveLikesAsync(int id);
    }
}
