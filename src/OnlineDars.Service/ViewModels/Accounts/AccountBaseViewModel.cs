using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.ViewModels.Accounts;

public class AccountBaseViewModel
{
	public long Id { get; set; }	
	public string FirstName { get; set; } = string.Empty;
	public string ImagePath { get; set; } = string.Empty;

}
