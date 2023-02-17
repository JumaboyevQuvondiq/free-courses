using OnlineDars.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
        public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);
        public Task<bool> UserEmailVerifyAsync(AccountLoginDto accountLoginDto);
        public  Task<bool> VerifyEmailAsync(AccountLoginDto accountLoginDto);

	}
}
