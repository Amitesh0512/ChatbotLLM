using ChatbotLLM.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotLLM.Controllers
{
    [ApiController]
    [Route("api/chatbot")]
    public class ChatbotController : ControllerBase
    {
        private readonly LlmService _llmService;
        public ChatbotController(LlmService llmService)
        {
            _llmService = llmService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskChatbot([FromBody] ChatRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                return BadRequest("Message cannot be empty.");

            var response = await _llmService.GetChatbotResponse(request.Message);
            return Ok(new { reply = response });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}
