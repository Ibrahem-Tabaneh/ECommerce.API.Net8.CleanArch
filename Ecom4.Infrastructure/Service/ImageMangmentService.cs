using Ecom4.Core.IService;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Service
{
    public class ImageMangmentService : IImageMangmentService
    {
        private readonly IWebHostEnvironment _env;
        public ImageMangmentService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<List<string>> AddImageAsync(
       IEnumerable<(string FileName, Stream Content)> files, string src)
        {
            var savedImages = new List<string>();
            var imageDirectory = Path.Combine("wwwroot", "images", src);

            Directory.CreateDirectory(imageDirectory);

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };

            foreach (var file in files)
            {
                if (file.Content == null || !file.Content.CanRead)
                    continue;

                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                    continue;

                var imageName = $"{Guid.NewGuid()}{extension}";
                var fullPath = Path.Combine(imageDirectory, imageName);

                try
                {
                    await using var stream = new FileStream(fullPath, FileMode.Create);
                    await file.Content.CopyToAsync(stream);

                    savedImages.Add($"Images/{src}/{imageName}");
                }
                catch
                {
                    // log error
                }
            }

            return savedImages;
        }

        public async Task DeleteImagesAsync(IEnumerable<string> imagePaths)
        {
            if (imagePaths == null || !imagePaths.Any())
                return;

            foreach (var path in imagePaths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                // حذف "/" من البداية لو موجودة
                var relativePath = path.TrimStart('/');

                // المسار الكامل
                var fullPath = Path.Combine(_env.WebRootPath, relativePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }

            await Task.CompletedTask;
        }

    }
}
