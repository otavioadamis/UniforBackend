﻿using UniforBackend.DAL.Data;
using UniforBackend.DAL.Helpers;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class MensagemRepo : IMensagemRepo
    {
        private readonly AppDbContext _dbContext;
        public MensagemRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Mensagem Add(Mensagem thisMensagem)
        {
            _dbContext.Mensagens.Add(thisMensagem);
            return thisMensagem;
        }

        public PagedResult<MensagemDTO> GetMessagesFromChatId(string chatId, int index)
        {
            var allMessages = from m in _dbContext.Mensagens
                              where m.ChatId == chatId
                              join senderUser in _dbContext.Users on m.Sender equals senderUser.Id
            orderby m.SendedAt descending
                              select new MensagemDTO
                              {
                                  Content = m.Content,
                                  SenderId = senderUser.Id,
                                  SenderName = senderUser.Nome,
                                  SendedAt = m.SendedAt,
                              };
            var pagedResult = PaginationHelper.Paginate(allMessages, index, 30);
            return pagedResult;
        }

        public void Delete(string _id)
        {
            var message = _dbContext.Mensagens.FirstOrDefault(x => x.Id == _id);
            _dbContext.Mensagens.Remove(message);
        }
    }
}
