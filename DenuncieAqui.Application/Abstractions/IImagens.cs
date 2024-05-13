using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface IImagens
    {
        Task<IEnumerable<Images>> GetImagesAsync();

        Task <Images> AddImagesAsync(Images images);

        Task DeleteImagesAsync(int id);
    }
}
