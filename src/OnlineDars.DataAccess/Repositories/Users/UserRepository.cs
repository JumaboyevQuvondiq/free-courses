using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces.Users;
using OnlineDars.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories.Users
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext context) : base(context)
		{
		}
	}
}
