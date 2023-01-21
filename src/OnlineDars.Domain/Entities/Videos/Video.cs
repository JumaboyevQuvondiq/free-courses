using OnlineDars.Domain.Common;
using OnlineDars.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Domain.Entities.Videos;

public class Video : Auditable
{
	
	public string VideoName { get; set; } = string.Empty;	
	public string VideoDescription { get; set; } = string.Empty;
	public string VideoPath { get; set; } = string.Empty;	
	public long ViewsCount { get; set; }
	public long CategoryId { get; set; }	
	public virtual Category Category { get; set; }	


}
