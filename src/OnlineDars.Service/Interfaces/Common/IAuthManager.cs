using OnlineDars.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Common
{
	public interface IAuthManager
	{
		public string GenerateToken(User user);
	}
}
