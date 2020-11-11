using System.Collections.Generic;

namespace Domain.Models
{
    public class Conversation
    {
        public List<Message> Messages { get; set; }
        public int NumberOfMessages { get; set; }
        public Rating Rating { get; set; }
    }
}
