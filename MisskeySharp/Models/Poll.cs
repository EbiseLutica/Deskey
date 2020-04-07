using System;
using System.Collections.Generic;

namespace MisskeySharp
{
    public class Poll
    {
        public bool Multiple { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public List<Choice> Choices { get; set; } = new List<Choice>();
    }
}
