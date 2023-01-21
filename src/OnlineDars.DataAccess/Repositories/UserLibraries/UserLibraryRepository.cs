using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces.UsersLibraries;
using OnlineDars.Domain.Entities.UserLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories.UserLibraries;

public class UserLibraryRepository : GenericRepository<UserLibrary>, IUserLibraryRepository
{
	public UserLibraryRepository(AppDbContext context) : base(context)
	{
	}
}
