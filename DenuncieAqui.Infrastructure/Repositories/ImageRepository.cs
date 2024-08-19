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
            try
            {
                // Adiciona a imagem ao contexto
                await _context.AddAsync(image);

                // Salva as mudanças no banco de dados
                await _context.SaveChangesAsync();

                // Retorna a imagem adicionada
                return image;
            }
            catch (Exception ex)
            {
                // Log detalhado de erro
                throw new ArgumentException($"Erro (repositório infra) ao adicionar imagem: {ex.Message}");
                throw new ArgumentException($"Stack Trace: {ex.StackTrace}");

            }
        }

        public async Task DeleteImageAsync(Guid id)
        {
            var image = await GetImageAsync(id);

            _context.Images.Remove(image!);
        }
    }
}
