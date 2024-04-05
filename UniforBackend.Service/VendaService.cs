using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.VendaTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Service
{
    public class VendaService : IVendaService
    {

        private readonly IVendaRepo _vendaRepo;
        private readonly IItemService _itemService;

        public VendaService(IVendaRepo vendaRepo, IItemService itemService) 
        {
            _vendaRepo = vendaRepo;
            _itemService = itemService;
        }

        public VendaDTO RealizaVenda(string itemId, string userId)
        {
            var newVenda = new Venda()
            {
                DataVenda = DateTime.UtcNow,
                ItemId = itemId,
                VendedorId = userId,
            };

            _vendaRepo.Add(newVenda);
            _vendaRepo.SaveChanges();

            //chama servico do item para atualizar status IsVendido;
            _itemService.VendeItem(itemId);

            var vendaResponse = _vendaRepo.GetVendaDTOById(newVenda.Id);
            return vendaResponse;
        }

        public IEnumerable<VendaDTO> GetAllVendasFromUser(string userId)
        {
            var allVendas = _vendaRepo.GetAllVendasFromUser(userId);
            return allVendas;
        }
    }
}
