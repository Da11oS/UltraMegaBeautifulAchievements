namespace Achievements.Domain.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
    
    public enum UserRole : byte
    {
        User = 1,
        Admin = 2
    }
}