using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [CustomAuthorize]
        [HttpPost("{receiverId}")]
        public ActionResult<ChatDTO> CreateChat(string receiverId)
        {
            var user = (User)HttpContext.Items["User"];
            
            var createdChat = _chatService.CreateChat(user.Id, receiverId);
            return Ok(createdChat);
        }

        [CustomAuthorize]
        [HttpGet("recentchats")]
        public ActionResult<IEnumerable<ChatDTO>> GetRecentChats()
        {
            var user = (User)HttpContext.Items["User"];
            
            var recentChats = _chatService.GetRecentChats(user.Id);
            return Ok(recentChats);
        }

        [CustomAuthorize]
        [HttpGet("{chatId}")]
        public ActionResult<IEnumerable<MensagemDTO>> GetAllMessagesFromChat(string chatId)
        {
            var allChatMessages = _chatService.GetMessagesFromChat(chatId);
            return Ok(allChatMessages);
        }
    }
}
