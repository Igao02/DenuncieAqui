using DenuncieAqui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenuncieAqui.Application.Abstractions
{
    public interface IImage
    {
        Task<IEnumerable<Image>> GetImagesAsync();

        Task <Image> AddImagesAsync(Image images);

        Task DeleteImagesAsync(int id);
    }
}
