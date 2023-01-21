using OnlineDars.Domain.Common;
using OnlineDars.Domain.Entities.Users;
using OnlineDars.Domain.Entities.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Domain.Entities.UserLibraries
{
	public class UserLibrary : BaseEntity
	{
		public long UserId { get; set; }
		public virtual User User { get; set; }
		public long VideoId { get; set; }
		public virtual Video Video { get; set; } 

	}
}
