﻿using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class ImagemRepo : IImagemRepo
    {
        private readonly AppDbContext _dbContext;
        public ImagemRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Imagem Add(Imagem thisImagem)
        {
            _dbContext.Imagens.Add(thisImagem);
            return thisImagem;
        }

        public IEnumerable<ImagemDTO> GetAllByItemId(string itemId) 
        {
            var query = from imagem in _dbContext.Imagens
                        where imagem.ItemId == itemId
                        select new ImagemDTO()
                        {
                            URL = $"https://uniforbackend-test.s3.amazonaws.com/{imagem.ItemId}_{imagem.Index}{imagem.Extensao}",
                            Index = imagem.Index,
                        };
            return query;
        }
    }
}
