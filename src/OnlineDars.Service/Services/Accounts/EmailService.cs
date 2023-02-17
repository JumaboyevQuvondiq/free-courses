using Microsoft.Extensions.Configuration;
using OnlineDars.DataAccess.DbContexts;
using OnlineDars.Domain.Exceptions;
using OnlineDars.Service.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using OnlineDars.Service.Dtos.Emails;
using Microsoft.EntityFrameworkCore;
using OnlineDars.Service.Interfaces.Accounts;

namespace OnlineDars.Service.Services.Accounts
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration, AppDbContext appDbContext)
        {
            _context = appDbContext;
            _config = configuration.GetSection("Email");
        }

        public async Task SendAsync(EmailMessageDto emailMessage)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config["Email"]));
            email.To.Add(MailboxAddress.Parse(emailMessage.To));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body.ToString() };

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["Email"], _config["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task VerifyPasswordAsync(ResetPasswordDto password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(p => p.Email == password.Email);

            if (admin is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "user not found!");

            var changedPassword = PasswordHasher.ChangePassword(password.Password, admin.Salt);

            admin.PasswordHash = changedPassword;

            _context.Admins.Update(admin);

            await _context.SaveChangesAsync();
        }
    }
}
