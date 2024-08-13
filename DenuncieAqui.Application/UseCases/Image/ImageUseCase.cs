using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace DenuncieAqui.Application.UseCases.ImageUseCase
{
    public class ImageUseCase
    {
        private readonly IImageRepository _imageRepository;
        
        private readonly string _imageStoragePath;

        public ImageUseCase(IImageRepository imageRepository, string imageStoragePath)
        {
            _imageRepository = imageRepository;
            _imageStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ReportImages", "Uploads");
        }

        public async Task<Image?> GetImageAsync(Guid id)
        {
            var image = await _imageRepository.GetImageAsync(id);

            return image;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await _imageRepository.GetListAsync();
        }

        //public async Task<Image> CreateImageAsync(Image image)
        //{
        //    return await _imageRepository.AddImageAsync(image);
        //}

        public async Task<Image> UploadAndSaveImageAsync(IFormFile file, Guid reportId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded.");

            // Crie o diretório se ele não existir
            Directory.CreateDirectory(_imageStoragePath);

            // Gere um nome de arquivo único
            var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_imageStoragePath, fileName);

            // Salve o arquivo no caminho especificado
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Crie uma nova entidade Image e salve no banco de dados
            var image = new Image
            {
                ImageUrl = Path.Combine("ReportImages", "Uploads", fileName), // Caminho relativo
                ImageDate = DateTime.UtcNow,
                ReportId = reportId
            };

            return await _imageRepository.AddImageAsync(image);
        }

        public async Task DeleteImageAsync(Guid id)
        {
            await _imageRepository.DeleteImageAsync(id);
        }
    }
}
