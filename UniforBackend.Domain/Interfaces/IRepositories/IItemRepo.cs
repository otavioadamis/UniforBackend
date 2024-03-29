﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IItemRepo
    {
        public void SaveChanges();
        public Item Add(Item thisItem);
        public Item GetById(string _id);
        public void Delete(string _id);
        public IEnumerable<ItemCardDTO> GetItensFromUserId(string userId);
        public ListItemCardResponse GetAllItens(int pagina);
    }
}
