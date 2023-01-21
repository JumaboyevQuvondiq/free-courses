using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces.Categories;
using OnlineDars.Domain.Common;
using OnlineDars.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories.Categories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context)
		{
		}
	}
}
