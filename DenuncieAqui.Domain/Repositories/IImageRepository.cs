using DenuncieAqui.Domain.Entities;

namespace DenuncieAqui.Domain.Repositories;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetImagesAsync();

    Task<Image> AddImageAsync(Image image);

    Task DeleteImageAsync(int id);
}
