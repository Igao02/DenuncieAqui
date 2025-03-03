﻿using DenuncieAqui.Domain.Entities;
using DenuncieAqui.Domain.Repositories;
using Microsoft.AspNetCore.Http;


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
            var maxFileSizeInBytes = 1024 * 1024 * 10;

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("Nenhum arquivo selecionado");
                }

                if (file.Length > maxFileSizeInBytes)
                {
                    throw new ArgumentException("Arquivo excede o tamanho máximo permitido");
                }

                if (!Directory.Exists(_imageStoragePath))
                {
                    Directory.CreateDirectory(_imageStoragePath);
                }

                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new ArgumentException("Tipo de arquivo não suportado");
                }

                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(_imageStoragePath, fileName);

                try
                {
                    Console.WriteLine("Iniciando cópia do arquivo...");

                    using var memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    Console.WriteLine("Arquivo copiado para o MemoryStream.");

                    using var fs = System.IO.File.Create(filePath);
                    fs.Write(fileBytes, 0, fileBytes.Length);
                    await memoryStream.CopyToAsync(fs);

                    Console.WriteLine("Arquivo salvo no sistema de arquivos.");

                    var imageUrl = $"/ReportImages/Uploads/{fileName}";
                    var imageDate = DateTime.Now;

                    var image = new Image(imageUrl, fileBytes, imageDate, reportId);

                    var uploadImages = await _imageRepository.AddImageAsync(image);
                    uploadedImages.Add(uploadImages);

                    Console.WriteLine("Imagem adicionada ao repositório.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar a imagem: {ex.Message}");
                    throw new ArgumentException($"Erro ao salvar a imagem: {ex.Message}");
                }
            }

            return uploadedImages;
        }

        public async Task DeleteImageAsync(Guid id)
        {
            await _imageRepository.DeleteImageAsync(id);
        }
    }
}