using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Common
{
	public interface IIdentityService
	{
		public long? Id { get; }
		public string Name { get; }
		public string Email { get; }
		public string ImagePath { get; }
		public string EmailVerify { get; }
	}
}
