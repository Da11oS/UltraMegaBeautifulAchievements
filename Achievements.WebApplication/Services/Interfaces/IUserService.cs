using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.Domain.ViewModels;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        LoginResponse Login(LoginRequest model);
        Task<LoginResponse> Register(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}