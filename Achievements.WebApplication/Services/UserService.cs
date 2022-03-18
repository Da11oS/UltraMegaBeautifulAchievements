using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.Domain.ViewModels;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Achievements.WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IEfRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
        
            if (user == null) return null;
            
        
            var token = _configuration.GenerateJwtToken(user);
        
            return new AuthenticateResponse(user, token);
        }

        public async Task<AuthenticateResponse> Register([FromBody]User user)
        {
            var addedUser = await _userRepository.Create(user);
        
            var response = Authenticate(new AuthenticateRequest
            {
                Username = user.Username,
                Password = user.Password
            });
            
            return response;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}