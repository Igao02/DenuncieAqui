using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetListAsync();

    Task <Image?> GetImageAsync(Guid id);

    Task<Image> AddImageAsync(Image image);

    Task DeleteImageAsync(Guid id);
}
