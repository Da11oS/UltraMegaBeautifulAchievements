using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.Domain.ViewModels;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
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

        public LoginResponse Login(LoginRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
        
            if (user == null) return null;
            
        
            var token = _configuration.GenerateJwtToken(user);
        
            return new LoginResponse(user, token);
        }

        public async Task<LoginResponse> Register(User user)
        {
            var addedUser = await _userRepository.Create(user);
        
            var response = Login(new LoginRequest
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