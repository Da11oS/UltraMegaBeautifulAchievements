using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        //AuthenticateResponse Authenticate(AuthenticateRequest model);
        //Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        Task<User> GetById(int id);
    }
}