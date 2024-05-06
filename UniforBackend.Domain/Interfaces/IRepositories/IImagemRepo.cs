using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.ImageTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface IImagemRepo
    {
        public void SaveChanges();
        public Imagem Add(Imagem thisImagem);
        public ImagemDTO GetById(string imagemId);
        public IEnumerable<ImagemDTO> GetAllByItemId(string itemId);
        public void Delete(string imageId);
    }
}
