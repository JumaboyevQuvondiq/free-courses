using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Entities.Users;
using OnlineDars.Service.Common.Security;
using OnlineDars.Service.Dtos.Accounts;
using OnlineDars.Service.Interfaces.Accounts;
using OnlineDars.Service.Interfaces.Common;
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
		private readonly IAuthManager _authManager;

		public AccountService(IUnitOfWork unitOfWork, IAuthManager authManager)
		{
			this._repository = unitOfWork;
			_authManager = authManager;
		}
		public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
		{
			var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
			if (emailedUser is  null) throw new Exception();

			var result = PasswordHasher.Verify(accountLoginDto.Password,emailedUser.Salt,emailedUser.PasswordHash);
			if (!result) throw new Exception();
			return _authManager.GenerateToken(emailedUser);
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

