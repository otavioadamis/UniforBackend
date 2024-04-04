using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.VendaTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IVendaRepo
    {
        public void SaveChanges();
        public Venda Add(Venda thisVenda);
        public IEnumerable<VendaDTO> GetAllVendasFromUser(string userId);
        public VendaDTO GetVendaDTOById(string vendaId);
    }
}
