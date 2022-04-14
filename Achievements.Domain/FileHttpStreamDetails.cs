namespace Achievements.Domain
{
    public class FileHttpStreamDetails
    {
        public string filePath { get; set; }
        public string contentType { get; set; }
        public byte[] bytes { get; set; }
    }
}