using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.DataAccess.Interfaces.Admins;
using OnlineDars.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Repositories.Admins;

public class AdminRepository: GenericRepository<Admin>, IAdminRepository
{
	public AdminRepository(AppDbContext context): base(context) { }
	
}
