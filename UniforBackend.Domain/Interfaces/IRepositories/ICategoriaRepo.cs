using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepo
    {
        public SubCategoria GetSubCategoriaByName(string name);
    }
}
