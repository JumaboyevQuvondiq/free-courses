using OnlineDars.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Domain.Entities.Categories;

public class Category : BaseEntity
{
	public string CategoryName { get; set; } = string.Empty;
	public string ImagePath { get; set; } = string.Empty;
	public string VideosCount { get; set; } = string.Empty;

}
