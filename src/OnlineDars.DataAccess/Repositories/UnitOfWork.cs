using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.DataAccess.Interfaces.Admins;
using OnlineDars.DataAccess.Interfaces.Categories;
using OnlineDars.DataAccess.Interfaces.Users;
using OnlineDars.DataAccess.Interfaces.UsersLibraries;
using OnlineDars.DataAccess.Interfaces.Videos;
using OnlineDars.DataAccess.Repositories.Admins;
using OnlineDars.DataAccess.Repositories.Categories;
using OnlineDars.DataAccess.Repositories.UserLibraries;
using OnlineDars.DataAccess.Repositories.Users;
using OnlineDars.DataAccess.Repositories.Videos;
using OnlineDars.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private AppDbContext DbContexts { get; }
		public IAdminRepository Admins { get; }

		public ICategoryRepository Categories { get; }

		public IUserRepository Users { get; }

		public IUserLibraryRepository UserLibreries { get; }

		public IVideoRepository Videos { get; }

		public UnitOfWork(AppDbContext appDbContext)
		{
			DbContexts = appDbContext;
			Admins = new AdminRepository(appDbContext);
			Categories = new CategoryRepository(appDbContext);
			Users = new UserRepository(appDbContext);
			UserLibreries = new UserLibraryRepository(appDbContext);
			Videos = new VideoRepository(appDbContext);
		}

		public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
		{
			return DbContexts.Entry(entity);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await DbContexts.SaveChangesAsync();
		}
	}
}
