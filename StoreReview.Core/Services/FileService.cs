using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoreReview.Core.Interfaces;

namespace StoreReview.Core.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public Task<string> UploadAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(paramName: nameof(file));
            }

            return UploadAsync(file.OpenReadStream, file.FileName, uniqueName: true);
        }

        public Task<string> UploadAsync(Func<Stream> openStream, string fileName, bool uniqueName)
        {
            string actualFileName = fileName;
            if (uniqueName)
                actualFileName = GetUniqueFileName(actualFileName);

            string path = Path.Combine(_filePath, actualFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            using (var stream = openStream())
            {
                stream.CopyTo(fileStream);
            }

            return Task.FromResult(_filePath);
        }

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(File.Exists(_filePath));
        }

        public Task DeleteAsync(string path)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            return Task.CompletedTask;
        }

        public Task<Stream> OpenReadAsync(string path)
        {
            return Task.FromResult((Stream)File.OpenRead(_filePath));
        }

        private static string GetUniqueFileName(string fileName)
        {
            return $"{fileName}_{Guid.NewGuid()}";
        }
    }
}