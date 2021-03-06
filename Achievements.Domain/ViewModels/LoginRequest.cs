using System.ComponentModel.DataAnnotations;

namespace Achievements.Domain.ViewModels
{
    /// <summary>
    /// Модель запроса аутентификации
    /// </summary>
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}