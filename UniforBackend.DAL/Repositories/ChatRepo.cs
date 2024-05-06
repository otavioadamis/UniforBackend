using System;
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
                                   on usersChat.Id equals chat.Id
                               join otherUsersChat in _dbContext.UsersChats
                                   on chat.Id equals otherUsersChat.Id
                               where otherUsersChat.UserId != userId // Exclude the logged-in user
                               join otherUser in _dbContext.Users
                                   on otherUsersChat.UserId equals otherUser.Id
                               orderby chat.UpdatedAt descending
                               select new ChatDTO
                               {
                                   LastMessage = chat.LatestMessage.Content,
                                   ChatName = otherUser.Nome,
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
                        }).FirstOrDefault();

            return query;
        }
    }
}
