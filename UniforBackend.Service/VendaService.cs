using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Exceptions;
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
            var itemVendido = _itemService.GetItemById(itemId);
            if(itemVendido == null)
            {
                throw new CustomException(new ErrorResponse
                {
                    Message = "Item não encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound,
                });
            }
            
            var newVenda = new Venda()
            {
                ItemId = itemVendido.Id,
                VendedorId = userId,
            };

            _vendaRepo.Add(newVenda);
            _vendaRepo.SaveChanges();

            _itemService.VendeItem(itemVendido.Id);

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
