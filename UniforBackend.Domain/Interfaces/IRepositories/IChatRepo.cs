﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IChatRepo
    {
        public void SaveChanges();
        public Chat Add(Chat thisChat);
        public IEnumerable<ChatDTO> GetChatsWithUsersIds(string chatId, string senderUserId);
        public IEnumerable<ChatDTO> GetRecentChatsFromUserId(string userId);
        public Chat GetById(string _id);
    }
}
