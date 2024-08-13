using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image?> GetImageAsync(Guid id) => await _context.Images.FindAsync(id);

        public async Task<IEnumerable<Image>> GetListAsync() => await _context.Images.ToListAsync();

        public async Task<Image> AddImageAsync(Image image)
        {
            await _context.AddAsync(image);

            await _context.SaveChangesAsync();
            
            return image;

        }

        public async Task DeleteImageAsync(Guid id)
        {
            var image = await GetImageAsync(id);

            _context.Images.Remove(image!);
        }
    }
}
