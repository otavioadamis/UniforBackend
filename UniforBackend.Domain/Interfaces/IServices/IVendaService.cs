using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.VendaTOs;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IVendaService
    {
        public VendaDTO RealizaVenda(string itemId, string userId);
        public IEnumerable<VendaDTO> GetAllVendasFromUser(string userId);
    }
}
