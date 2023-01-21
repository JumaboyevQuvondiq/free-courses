using OnlineDars.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Categories
{
    public interface ICategoryService
    {
        public Task<Category> GetAsync(long id);
        public Task<IList<Category>> GetAllAsync();
    }
}
