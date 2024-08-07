﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class ChatRepo : IChatRepo
    {
        private readonly AppDbContext _dbContext;
        public ChatRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Chat Add(Chat thisChat)
        {
            _dbContext.Chats.Add(thisChat);
            return thisChat;
        }

        public Chat GetById(string _id)
        {
            var chat = _dbContext.Chats.FirstOrDefault(x => x.Id == _id);
            return chat;
        }

        public void Delete(string _id)
        {
            var chat = _dbContext.Chats.FirstOrDefault(x => x.Id == _id);
            _dbContext.Chats.Remove(chat);
        }

        public IEnumerable<ChatDTO> GetRecentChatsFromUserId(string userId)
        {
            var recentChats = (from usersChat in _dbContext.UsersChats
                               where usersChat.UserId == userId
                               join chat in _dbContext.Chats
                                   on usersChat.ChatId equals chat.Id
                               join otherUsersChat in _dbContext.UsersChats
                                   on chat.Id equals otherUsersChat.ChatId
                               where otherUsersChat.UserId != userId // Nao quero retornar o proprio usuario logado na query
                               join otherUser in _dbContext.Users
                                   on otherUsersChat.UserId equals otherUser.Id
                               orderby chat.UpdatedAt descending
                               select new ChatDTO
                               {
                                   Id = chat.Id,
                                   LastMessage = chat.LatestMessage.Content,
                                   ChatName = otherUser.Nome,
                                   OtherUserId = otherUser.Id,
                                   UnreadMessages = usersChat.UnreadMessages,
                               }).Distinct().ToList();
            return recentChats;
        }

        public ChatDTO GetDTOByUsers(string senderUserId, string receiverId)
        {
            var query = (from userchat1 in _dbContext.UsersChats
                        join userchat2 in _dbContext.UsersChats on userchat1.ChatId equals userchat2.ChatId
                        where userchat1.UserId == senderUserId && userchat2.UserId == receiverId
                        join receiverUser in _dbContext.Users on receiverId equals receiverUser.Id
                        join chat in _dbContext.Chats on userchat1.ChatId equals chat.Id
                        select new ChatDTO()
                        {
                            ChatName = receiverUser.Nome,
                            Id = chat.Id,
                            LastMessage = chat.LatestMessage.Content,
                            OtherUserId = receiverUser.Id,
                            UnreadMessages = userchat1.UnreadMessages,
                        }).FirstOrDefault();
            return query;
        }

        public UserChat GetUserChatFromUserIdAndChatId(string userId, string chatId)
        {
            var otherUserchat = _dbContext.UsersChats.FirstOrDefault(u => u.UserId == userId && u.ChatId == chatId);
            return otherUserchat;
        }
    }
}
