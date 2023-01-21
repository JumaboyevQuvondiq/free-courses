using Microsoft.EntityFrameworkCore;
using OnlineDars.DataAccess.Configurations;
using OnlineDars.Domain.Entities.Admins;
using OnlineDars.Domain.Entities.Categories;
using OnlineDars.Domain.Entities.UserLibraries;
using OnlineDars.Domain.Entities.Users;
using OnlineDars.Domain.Entities.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.DbContexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }

		public virtual DbSet<Admin> Admins { get; set; } = default!;
		public virtual DbSet<Category> Categories { get; set; } = default!;
		public virtual DbSet<Video> Videos { get; set; } = default!;
		public virtual DbSet<User> Users { get; set; } = default!;
		public virtual DbSet<UserLibrary> UserLibraries { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new SuperAdminConfigurtion());
			
		}
		
		
	}
}
