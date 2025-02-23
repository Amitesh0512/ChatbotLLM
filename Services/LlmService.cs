using System.Text.Json;

namespace ChatbotLLM.Services
{
    public class LlmService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly string _apiUrl = "https://api.groq.com/openai/v1/chat/completions"; // ✅ Correct API URL


        public LlmService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Groq:ApiKey"];
            _model = configuration["Groq:Model"];
        }

        public async Task<string> GetChatbotResponse(string userMessage)
        {
            var requestBody = new
            {
                model = _model, // ✅ Ensure model is valid
                messages = new[]
           {
                new { role = "system", content = "You are a helpful chatbot." },
                new { role = "user", content = userMessage }
            },
                temperature = 0.7,
                max_tokens = 256
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl);
            request.Headers.Add("Authorization", $"Bearer {_apiKey}"); // ✅ Ensure API Key is sent
            request.Headers.Add("Accept", "application/json"); // ✅ Ensure JSON response
            request.Content = JsonContent.Create(requestBody);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Groq API Error: {response.StatusCode} - {errorResponse}");
            }

            var result = await response.Content.ReadAsStringAsync();
            using JsonDocument jsonDoc = JsonDocument.Parse(result);
            return jsonDoc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
