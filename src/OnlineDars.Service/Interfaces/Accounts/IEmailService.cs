using OnlineDars.Service.Dtos.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Accounts
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessageDto emailMessageDto);

        public Task VerifyPasswordAsync(ResetPasswordDto password);
    }
}
