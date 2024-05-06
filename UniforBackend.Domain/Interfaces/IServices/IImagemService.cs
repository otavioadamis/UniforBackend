using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Interfaces.IServices
{
    public interface IImagemService
    {
        public Task DeleteImageAsync(string imageId);
    }
}
