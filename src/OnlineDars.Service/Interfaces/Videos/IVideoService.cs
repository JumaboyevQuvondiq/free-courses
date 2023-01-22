using OnlineDars.Service.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Interfaces.Videos
{
    public interface IVideoService
    {
        public Task<VideoViewModel> GetAsync(long id);
        public Task<IList<VideoBaseViewModel>> GetAllAsync(long categoryId);
    }
}
