using OnlineDars.Domain.Entities.Users;
using OnlineDars.Service.Common.Attributes;
using OnlineDars.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required,MaxLength(100),MinLength(2)]
        public string FullName { get; set; } = string.Empty;
        [Required,Email]
        public string Email { get; set; } = string.Empty;
        [Required,StrongPassword]
        public string Password { get; set; } = string.Empty; 

        public static implicit operator User(AccountRegisterDto accountRegisterDto)
        {
            return new User()
            {
                FullName = accountRegisterDto.FullName,
                Email = accountRegisterDto.Email,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime(),

            };
        }
    }
}
