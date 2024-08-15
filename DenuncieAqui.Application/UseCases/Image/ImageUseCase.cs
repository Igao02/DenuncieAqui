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

        public async Task<List<Image>> UploadImagesAsync(IEnumerable<IFormFile> files, Guid reportId)
        {
            var uploadedImages = new List<Image>();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("Nenhum arquivo selecionado");
                }

                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new ArgumentException("Unsupported file type");
                }

                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(_imageStoragePath, fileName);

                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    await file.CopyToAsync(stream);
                //}

                var imageUrl = $"/ReportImages/Uploads/{fileName}";
                var imageDate = DateTime.UtcNow;

                var image = new Image(imageUrl, imageDate, reportId);
                //uploadedImages.Add(image);

                var uploadImages = await _imageRepository.AddImageAsync(image);
            }

            return uploadedImages;
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