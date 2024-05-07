using Microsoft.AspNetCore.SignalR;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ChatTOs;

namespace UniforBackend.Service
{
    public class ChatHubService : Hub
    {
        private readonly IChatService _chatService;
        public ChatHubService(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task JoinChat(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task SendMessageToChat(string toChatId, string content, string fromUserId)
        {
            await _chatService.SaveMessageAsync(toChatId, content, fromUserId);
            await Clients.Group(toChatId).SendAsync("ReceiveMessage", content);
        }
    }
}

//{"type":1, "target":"JoinChat", "arguments":["354e170c-dec1-499c-90e9-ead300396da1"]}
//{"type":1, "target":"SendMessageToChat", "arguments":["354e170c-dec1-499c-90e9-ead300396da1", "mensagem", "User1"]}
//{"protocol":"json","version":1}
