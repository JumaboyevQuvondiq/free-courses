using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineDars.DataAccess.Interfaces.Admins;
using OnlineDars.DataAccess.Interfaces.Categories;
using OnlineDars.DataAccess.Interfaces.Users;
using OnlineDars.DataAccess.Interfaces.UsersLibraries;
using OnlineDars.DataAccess.Interfaces.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Interfaces
{
	public interface IUnitOfWork
	{
		public IAdminRepository Admins { get; }
		public ICategoryRepository Categories { get; }
		public IUserRepository Users { get; }
		public IUserLibraryRepository UserLibreries { get; }	
		public IVideoRepository Videos { get; }

		public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		public Task<int> SaveChangesAsync();
	}
}
