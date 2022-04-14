using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain;
using Achievements.Domain.Models;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace Achievements.WebApplication.Services
{
    public class StoredFileService : IStoredFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IEfRepository<StoredFile> _fileRepository;
        private readonly IUserService _userService;

        public StoredFileService(IConfiguration configuration, IEfRepository<StoredFile> fileRepository, IUserService userService)
        {
            _configuration = configuration;
            _fileRepository = fileRepository;
            _userService = userService;
        }
        
        public async Task<bool> DoStoreFile(IFormFile file, User user)
        {
            try
            {
                var fileIdentifier = Guid.NewGuid();
                var fileExtension = file.FileName.Split('.').Last();
                
                await StoreFileOnPhysicalSpace(file, fileIdentifier, fileExtension);
                await AddStoredFile(user, fileIdentifier, fileExtension, file);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private async Task StoreFileOnPhysicalSpace(IFormFile file, Guid fileIdentifier, string fileExtension)
        {
            var size = file.Length;

            if (size is <= 0 or > 2097152) return;
            
            var filePath = Path.Combine(_configuration["StoredFilesPath"], 
                fileIdentifier.ToString()) + '.' + fileExtension;

            if(!Directory.Exists(_configuration["StoredFilesPath"]))
                Directory.CreateDirectory(_configuration["StoredFilesPath"]);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        private async Task<int> AddStoredFile(User user, Guid fileIdentifier, string fileExtension, IFormFile file)
        {
            var storedFile = new StoredFile
            {
                Identifier = fileIdentifier,
                Directory = _configuration["StoredFilesPath"],
                Extension = fileExtension,
                ContentType = file.ContentType,
                Timestamp = DateTime.Now,
                User = user
            };
            
            return await _fileRepository.Create(storedFile);
        }

        public async Task<FileHttpStreamDetails> GetStoredFile(User user)
        {
            var storedFile = _fileRepository.GetAll().FirstOrDefault();

            if (storedFile == null) return null;
            
            var filePath = Path.Combine(_configuration["StoredFilesPath"], 
                storedFile.Identifier.ToString(), storedFile.Extension);
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out var contentType))
                contentType = "application/octet-stream";

            var bytes = await File.ReadAllBytesAsync(filePath);
            
            return new FileHttpStreamDetails
            {
                filePath = filePath,
                contentType = contentType,
                bytes = bytes
            };
        }
    }
}