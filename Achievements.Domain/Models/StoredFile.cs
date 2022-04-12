using System;

namespace Achievements.Domain.Models
{
    /// <summary>
    /// Модель сохраненного файла
    /// </summary>
    public class StoredFile : BaseEntity
    {
        public Guid Identifier { get; set; }
        public string Directory { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public DateTime Timestamp { get; set; }
        public User User { get; set; }
    }
}