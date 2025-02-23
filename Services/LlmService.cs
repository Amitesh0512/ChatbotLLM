namespace ChatbotLLM.Services
{
    public class LlmService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public LlmService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        public async Task<string> GetChatbotResponse(string userMessage)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "You are a helpful chatbot." },
                new { role = "user", content = userMessage }
            },
                max_tokens = 150
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            request.Content = JsonContent.Create(requestBody);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return result?.choices[0]?.message?.content ?? "Sorry, I couldn't understand that.";
        }
    }
}
