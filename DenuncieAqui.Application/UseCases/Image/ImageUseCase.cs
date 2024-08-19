﻿using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;


namespace DenuncieAqui.Application.UseCases.ImageUseCase
{
    public class ImageUseCase
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _imageStoragePath;
        //private readonly IHostingEnvironment _hostingEnvironment;

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

                try
                {
                    // Cria um MemoryStream para armazenar o conteúdo do arquivo
                    using var memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    // Salva o arquivo na pasta local
                    using var fs = System.IO.File.Create(filePath);
                    fs.Write(fileBytes, 0, fileBytes.Length);
                    await memoryStream.CopyToAsync(fs);

                    // Cria a URL da imagem
                    var imageUrl = $"/ReportImages/Uploads/{fileName}";
                    var imageDate = DateTime.UtcNow;

                    // Cria a entidade Image com o novo campo ConteudoArquivo
                    var image = new Image(imageUrl, fileBytes, imageDate, reportId);

                    // Adiciona a imagem à lista de imagens carregadas
                    var uploadImages = await _imageRepository.AddImageAsync(image);
                    uploadedImages.Add(uploadImages);
                }
                catch (Exception ex)
                {
                    // Log de erro
                    throw new ArgumentException($"Erro ao salvar a imagem: {ex.Message}");
                }
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