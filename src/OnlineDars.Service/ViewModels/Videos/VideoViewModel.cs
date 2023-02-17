using OnlineDars.Domain.Entities.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.ViewModels.Videos
{
    public class VideoViewModel
    {
        public long Id { get; set; }    
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoPath { get; set; } = string.Empty;
        public long ViewsCount { get; set; }    
       
    }
}
