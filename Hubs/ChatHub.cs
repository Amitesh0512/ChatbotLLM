using ChatbotLLM.Services;
using Microsoft.AspNetCore.SignalR;

namespace ChatbotLLM.Hubs
{
    public class ChatHub: Hub
    {
        private readonly LlmService _llmService;
        public ChatHub(LlmService llmService)
        {
            _llmService = llmService;
        }

        public async Task SendMessage(string user, string message)
        {
            var response = await _llmService.GetChatbotResponse(message);
            await Clients.All.SendAsync("ReceiveMessage", user, response);
        }
    }
}
