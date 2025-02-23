# 🚀 Groq Chatbot API using .NET Core & SignalR

This is a **.NET Core Web API** chatbot powered by **Groq's LLM (`mixtral-8x7b-32768`)**. It supports **real-time chat via SignalR**, **JWT authentication**, and **chat history storage in SQL Server**.

---

## 📌 **Features**
✅ **Groq AI-Powered Chatbot** (Uses `mixtral-8x7b-32768`)  
✅ **Real-time WebSocket Chat** with SignalR  
✅ **JWT Authentication** for security  
✅ **SQL Server Database** to store chat history  
✅ **REST API for chatbot communication**  
✅ **Scalable & Deployable on Azure/AWS**  

---

## 🛠️ **Prerequisites**
Before running this project, ensure you have:

- **.NET 7 or 8 SDK** → [Download](https://dotnet.microsoft.com/en-us/download)
- **SQL Server** → [Download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Groq API Key** → [Sign Up](https://console.groq.com/)
- **Postman or cURL** for testing APIs

---

## 📂 **Project Structure**
ChatbotLLM │── ChatbotLLM.sln # Solution File │── appsettings.json # Configuration Settings │── Program.cs # API Startup │── Controllers/ │ ├── ChatbotController.cs # REST API for chatbot │ ├── AuthController.cs # JWT Authentication │── Hubs/ │ ├── ChatHub.cs # SignalR for Real-Time Chat │── Models/ │ ├── ChatMessage.cs # Chat Message Model │ ├── User.cs # User Model │── Services/ │ ├── LlmService.cs # Communicates with Groq API │ ├── JwtService.cs # Generates JWT Tokens │── Data/ │ ├── ApplicationDbContext.cs # EF Core Database Context │── Migrations/ # EF Core Migrations

