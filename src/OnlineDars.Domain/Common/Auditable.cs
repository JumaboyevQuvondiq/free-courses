using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Domain.Common
{
	public class Auditable : BaseEntity
	{
		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}
