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

        public async Task ConnectOnLogin(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task JoinChat(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task SendMessageToChat(SendMensagemDTO mensagem)
        {
            var mensagemSocketDTO = await _chatService.SaveMessageAsync(mensagem.ToChatId, mensagem.Content, mensagem.FromUserId);
            await Clients.Group(mensagem.ToUserId).SendAsync("ReceiveMessage", mensagemSocketDTO);
        }
    }
}

//{"type":1, "target":"JoinChat", "arguments":["99f7a94f-1441-423d-8ba1-3c2371624c05"]}
//{"type":1, "target":"SendMessageToChat", "arguments":["354e170c-dec1-499c-90e9-ead300396da1", "mensagem", "User1"]}
//{"protocol":"json","version":1}
