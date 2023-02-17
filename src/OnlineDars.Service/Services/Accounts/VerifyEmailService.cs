using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Exceptions;
using OnlineDars.Service.Dtos.Accounts;
using OnlineDars.Service.Dtos.Emails;
using OnlineDars.Service.Interfaces.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Services.Accounts
{
    public class VerifyEmailService : IVerifyEmailService
    {
        private readonly IMemoryCache _cache;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _context;

        public VerifyEmailService(IMemoryCache cache, IEmailService email, IUnitOfWork appDbContext)
        {
            _cache = cache;
            _emailService = email;
            _context = appDbContext;
        }
        public async Task<bool> SendCodeAsync(SendCodeToEmailDto sendCodeToEmailDto)
        {
            int code = new Random().Next(1000, 9999);

            _cache.Set(sendCodeToEmailDto.Email, code, TimeSpan.FromMinutes(3));

            var message = new EmailMessageDto()
            {
                To = sendCodeToEmailDto.Email,
                Subject = "Verification code",
                Body = code,
            };

            await _emailService.SendAsync(message);

            return true;
        }

      

        public async Task<bool> VerifyEmail(EmailVerifyDto emailVerifyDto)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailVerifyDto.Email);

            if (entity == null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found!");

            if (_cache.TryGetValue(emailVerifyDto.Email, out int exceptedCode))
            {
                if (exceptedCode != emailVerifyDto.Code)
                    throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is wrong!");

                _context.Users.Update(entity.Id,entity);

                await _context.SaveChangesAsync();
            }
            else
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is expired");

            return true;
        }

       

        public async Task<bool> VerifyPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _context.Admins.FirstOrDefaultAsync(p => p.Email == resetPasswordDto.Email);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "user not found");

            if (_cache.TryGetValue(resetPasswordDto.Email, out int code))
            {
                if (code != resetPasswordDto.Code)
                    throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is wrong");
            }
            else
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is expired");

            return true;
        }

       
    }
}
