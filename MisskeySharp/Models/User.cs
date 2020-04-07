using System;
using System.Collections.Generic;

namespace MisskeySharp
{
    public interface IIdentifiedObject
    {
        string Id { get; set; }
    }

    public class User : IIdentifiedObject
    {
        public string Id { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserName { get; set; } = "";
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? AvatarUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? Birthday { get; set; }
        public string? Host { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersCount { get; set; }
        public int NotesCount { get; set; }
        public bool IsBot { get; set; }
        public bool IsCat { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }
        public bool IsLocked { get; set; }
        public bool HasUnreadSpecifiedNotes { get; set; }
        public bool HasUnreadMentions { get; set; }
        public List<string> PinnedNoteIds { get; set; } = new List<string>();
        public List<Note> PinnedNotes { get; set; } = new List<Note>();
    }
}
