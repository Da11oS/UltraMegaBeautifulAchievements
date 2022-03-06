using System;

namespace Achievements.Domain.Models.Entities
{
    /// <summary>
    /// Модель сохраненного файла
    /// </summary>
    public class StoredFile : BaseEntity
    {
        public string Name { get; set; }
        public Guid Identifier { get; set; }
        public string Directory { get; set; }
        public DateTime Timestamp { get; set; }
        public int IdUser { get; set; } // позже - модель юзера
    }
}