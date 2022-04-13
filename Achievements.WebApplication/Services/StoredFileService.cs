using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Achievements.WebApplication.Services
{
    public class StoredFileService : IStoredFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IEfRepository<StoredFile> _fileRepository;

        public StoredFileService(IConfiguration configuration, IEfRepository<StoredFile> fileRepository)
        {
            _configuration = configuration;
            _fileRepository = fileRepository;
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

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        private async Task AddStoredFile(User user, Guid fileIdentifier, string fileExtension, IFormFile file)
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
            
            var addedUser = await _fileRepository.Create(storedFile);
        }

        public StoredFile GetStoredFile(User user)
        {
            // пока чето не так
            return _fileRepository.GetAll().FirstOrDefault(x => x.User.Id == user.Id);
        }
    }
}