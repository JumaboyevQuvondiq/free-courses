using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Entities.Users;
using OnlineDars.Service.Common.Security;
using OnlineDars.Service.Dtos.Accounts;
using OnlineDars.Service.Interfaces.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Services.Accounts
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _repository;
		public AccountService(IUnitOfWork unitOfWork)
		{
			this._repository = unitOfWork;
		}
		public Task<string> LoginAsync(AccountLoginDto accountLoginDto)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
			if (emailedUser is not null) throw new Exception();			

			var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
			var user = (User)accountRegisterDto;
			user.PasswordHash = hasherResult.Hash;
			user.Salt = hasherResult.Salt;

			_repository.Users.Add(user);
			var dbResult = await _repository.SaveChangesAsync();
			return dbResult > 0;
		}
	}
}

