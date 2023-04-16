using System;

namespace LeetSpeak.Shared.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string OriginalText { get; set; }
        public string FormattedText { get; set; }
        public DateTime CreatingDate { get; set; }
        public string CreatingUser { get; set; }
    }
}
