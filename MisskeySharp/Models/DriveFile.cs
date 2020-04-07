using System;

namespace MisskeySharp
{
    public class DriveFile : IIdentifiedObject
    {
        public string Id { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Md5 { get; set; } = "";
        public int Size { get; set; }
        public string? Url { get; set; }
        public string? FolderId { get; set; }
        public bool IsSensitive { get; set; }
    }
}
