using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ChatTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IMensagemRepo
    {
        public void SaveChanges();
        public Mensagem Add(Mensagem thisMessage);
        public IEnumerable<MensagemDTO> GetMessagesFromChatId(string chatId);
        public void Delete(string _id);
    }
}
