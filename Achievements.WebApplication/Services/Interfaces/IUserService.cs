using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.Domain.ViewModels;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(User user);
        IEnumerable<User> GetAll();
        Task<User> GetById(int id);
    }
}