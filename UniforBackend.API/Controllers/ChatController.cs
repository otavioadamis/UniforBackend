﻿using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
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
        public ActionResult<PagedResult<MensagemDTO>> GetAllMessagesFromChat(string chatId, int index = 1)
        {
            if(index < 1) { index = 1; }
            var user = (User)HttpContext.Items["User"];
            var allChatMessages = _chatService.GetMessagesFromChat(chatId, index, user.Id);
            return Ok(allChatMessages);
        }

        [CustomAuthorize]
        [HttpPatch("resetUnread")]
        public async Task<ActionResult> ResetUnreadMessagesOfChat(string chatId)
        {
            var user = (User)HttpContext.Items["User"];
            await _chatService.ResetUnreadMessagesOfChat(chatId, user.Id);
            return Ok();
        }
    }
}
