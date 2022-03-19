using System;
using System.IO;
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
                var fileIdentifier = new Guid();
                await StoreFileOnPhysicalSpace(file, fileIdentifier);
                await AddStoredFile(fileIdentifier, user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Task<StoredFile> GetFile()
        {
            throw new NotImplementedException();
        }
        
        private async Task StoreFileOnPhysicalSpace(IFormFile file, Guid fileIdentifier)
        {
            var size = file.Length;

            if (size is <= 0 or > 2097152) return;
            
            var filePath = Path.Combine(_configuration["StoredFilesPath"], 
                fileIdentifier.ToString());

            await using var stream = File.Create(filePath);
            await file.CopyToAsync(stream);
        }

        private async Task AddStoredFile(Guid fileIdentifier, User user)
        {
            var storedFile = new StoredFile
            {
                Identifier = fileIdentifier,
                Directory = _configuration["StoredFilesPath"],
                Timestamp = DateTime.Now,
                User = user
            };
            
            var addedUser = await _fileRepository.Create(storedFile);
        }
    }
}