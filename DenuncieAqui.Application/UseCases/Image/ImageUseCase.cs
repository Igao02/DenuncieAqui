using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DenuncieAqui.Application.UseCases.ImageUseCase
{
    public class ImageUseCase
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _imageStoragePath;

        public ImageUseCase(IImageRepository imageRepository)
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

        [HttpPost]
        public async Task<Image> UploadImageAsync(IFormFile file, Guid reportId, Report report)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_imageStoragePath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (IOException ex)
            {
                // Log e gerenciar a exceção
                throw new Exception("Um erro ocorreu ao tentar salvar o arquivo", ex);
            }

            var imageUrl = $"/ReportImages/Uploads/{file.FileName}";
            var imageDate = DateTime.UtcNow;

            var image = new Image(imageUrl, imageDate, reportId, report);

            return await _imageRepository.AddImageAsync(image);
        }

        public async Task DeleteImageAsync(Guid id)
        {
            await _imageRepository.DeleteImageAsync(id);

            //var image = await _imageRepository.GetImageByIdAsync(id);
            //if (image != null)
            //{
            //    var filePath = Path.Combine(_imageStoragePath, image.ImageUrl);
            //    if (File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //    }
            //    await _imageRepository.DeleteImageAsync(id);
            //}
        }
    }
}