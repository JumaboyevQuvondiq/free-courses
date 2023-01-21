using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDars.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.DataAccess.Configurations
{
	public class SuperAdminConfigurtion : IEntityTypeConfiguration<Admin>
	{
		public void Configure (EntityTypeBuilder<Admin> builder)
		{
			builder.HasData(new Admin()
			{
				Id= 1,
				FirstName = "Quvondiq",
				LastName = "Jumaboyev",
				Email = "Jumaboyevquvondiqm5202@gmail.com",
				IsHead = true,
				EmailVerfiry = true,
				BirthDate = DateTime.Parse("03.24.2002").ToUniversalTime(),
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,	
				PassportSeriaNumber = "AC 1234567",
				PhoneNumber = "+998945910824",
				ImagePath = "assets/Images/JumabyevQuvondiq.jpg",
				Salt = "383ff037-82be-4a48-9e67-e6a34a29ba13",
				PasswordHash = "20421e54775b843907b930e9f5c081765a1c7ac163fbb068a9b7991172a3a95b"


			});
		}
	}
}
