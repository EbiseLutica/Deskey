using System;
using System.Collections.Generic;

namespace MisskeySharp
{
    public class Note : IIdentifiedObject
    {
        public static readonly string VisibilityPublic = "public";
        public static readonly string VisibilityHome = "home";
        public static readonly string VisibilityFollowers = "followers";
        public static readonly string VisibilitySpecified = "specified";

        public string Id { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string? Text { get; set; }
        public string? Cw { get; set; }
        public string UserId { get; set; } = "";
        public User User { get; set; }
        public string? ReplyId { get; set; }
        public string? RenoteId { get; set; }
        public User? Reply { get; set; }
        public User? Renote { get; set; }
        public bool ViaMobile { get; set; }
        public bool IsHidden { get; set; }
        public string Visibility { get; set; } = "public";
        public List<string> FileIds { get; set; } = new List<string>();
        public List<DriveFile> Files { get; set; } = new List<DriveFile>();
        public Poll? Poll { get; set; }
    }
}
