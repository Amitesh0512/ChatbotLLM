namespace ChatbotLLM.Models
{
    public class ChatMessages
    {
        public class ChatMessage
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string Message { get; set; }
            public string BotResponse { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        }
    }
}
