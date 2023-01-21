using Microsoft.EntityFrameworkCore;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Entities.Categories;
using OnlineDars.Service.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _repository;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork;
        }
        public async Task<IList<Category>> GetAllAsync()
        {
            return await _repository.Categories.GetAll().ToListAsync();
        }

        public Task<Category> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
