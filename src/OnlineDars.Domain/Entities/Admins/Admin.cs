using OnlineDars.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Domain.Entities.Admins
{
    public class Admin : Auditable
    {
		public string FirstName { get; set; } = String.Empty;
		public string LastName { get; set; } = String.Empty;
		public string? ImagePath { get; set; }
		public DateTime BirthDate { get; set; }
		public string PhoneNumber { get; set; } = String.Empty;
		public string PassportSeriaNumber { get; set; } = String.Empty;
		public string Email { get; set; } = string.Empty;
		public bool EmailVerfiry { get; set; }	
		public string PasswordHash { get; set; } = string.Empty;
		public string Salt { get; set; } = string.Empty;
		public bool IsHead { get; set; } = false;
	}
}
