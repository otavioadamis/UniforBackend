using Microsoft.Extensions.Configuration;
using UniforBackend.DAL.Data;
using UniforBackend.Domain.Interfaces.IRepositories;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.DAL.Repositories
{
    public class ImagemRepo : IImagemRepo
    {
        private readonly AppDbContext _dbContext;
        private readonly string? _bucketName;
        public ImagemRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            _dbContext = appDbContext;
            _bucketName = configuration["AwsConfiguration:BucketName"];
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

        public ImagemDTO GetById(string imagemId)
        {
            var imagem = _dbContext.Imagens.FirstOrDefault(x => x.Id == imagemId);
            return new ImagemDTO()
            {
                Id = imagem.Id,
                URL = $"https://{_bucketName}.s3.amazonaws.com/{imagem.ItemId}_{imagem.Index}{imagem.Extensao}",
                Index = imagem.Index,
            };
        }

        public List<ImagemDTO> GetAllByItemId(string itemId) 
        {
            var query = from imagem in _dbContext.Imagens
                        where imagem.ItemId == itemId
                        select new ImagemDTO()
                        {
                            Id = imagem.Id,
                            URL = $"https://{_bucketName}.s3.amazonaws.com/{imagem.ItemId}_{imagem.Index}{imagem.Extensao}",
                            Index = imagem.Index,
                        };
            return query.ToList();
        }

        public void Delete(string imageId)
        {
            var imagem = _dbContext.Imagens.FirstOrDefault(x => x.Id == imageId);
            _dbContext.Imagens.Remove(imagem);
        }
    }
}
