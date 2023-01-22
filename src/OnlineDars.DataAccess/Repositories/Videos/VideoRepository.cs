using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces.Videos;
using OnlineDars.Domain.Entities.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories.Videos
{
	public class VideoRepository : GenericRepository<Video>, IVideoRepository
	{
		public VideoRepository(AppDbContext context) : base(context)
		{
		}
		public IQueryable GetAll(long categroyId) => _dbSet.Where(x=>x.CategoryId== categroyId);	
	}
}
