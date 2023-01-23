using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Dtos.Accounts;

public class AccountLoginDto
{
    [Required(ErrorMessage ="Email kiritish majburiy")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email kiritish majburiy")]
    public string Password { get; set; } = string.Empty;
}
