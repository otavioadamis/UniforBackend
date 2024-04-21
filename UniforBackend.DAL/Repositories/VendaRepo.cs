using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.VendaTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class VendaRepo : IVendaRepo
    {
        private readonly AppDbContext _dbContext;
        public VendaRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Venda Add(Venda thisVenda)
        {
            _dbContext.Vendas.Add(thisVenda);
            return thisVenda;
        }

        //todo -> retornar informacoes do vendedor
        public VendaDTO GetVendaDTOById(string vendaId)
        {
            var vendaDTO = (
                from venda in _dbContext.Vendas
                where vendaId == venda.Id
                join item in _dbContext.Itens on venda.ItemId equals item.Id
                select new VendaDTO
                {
                    Id = venda.Id,
                    DataVenda = venda.DataVenda,
                    NomeItem = item.Nome,
                    preco = item.Preco,
                }).FirstOrDefault();
            return vendaDTO;
        }

        //todo -> paginação
        public IEnumerable<VendaDTO> GetAllVendasFromUser(string userId)
        {
            var allVendasDTO = (
                from venda in _dbContext.Vendas
                where venda.VendedorId == userId
                join item in _dbContext.Itens on venda.VendedorId equals item.UserId
                select new VendaDTO
                {
                    Id = venda.Id,
                    DataVenda = venda.DataVenda,
                    NomeItem = item.Nome,
                    preco = item.Preco,
                });
            return allVendasDTO;
        }
    }
}
