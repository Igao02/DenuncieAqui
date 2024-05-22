using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface IComments
    {
        Task <IEnumerable<Comments>> GetCommentsAsync ();

        Task <Comments> AddCommentsAsync(Comments comments);

        Task DeleteCommentsAsync (int id);

        Task EditeCommentsAsync (int id);

        Task SumCommentsAsync(int id);
    }
}
