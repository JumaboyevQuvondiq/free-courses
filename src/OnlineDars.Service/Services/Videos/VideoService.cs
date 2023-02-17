using Microsoft.EntityFrameworkCore;
using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Entities.Videos;
using OnlineDars.Domain.Exceptions;
using OnlineDars.Service.Interfaces.Videos;
using OnlineDars.Service.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDars.Service.Services.Video
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<VideoBaseViewModel>> GetAllAsync(long categoryId)
        {
            var res = _unitOfWork.Videos.GetAll().Where(x=>x.CategoryId == categoryId)
                .Select(x => new VideoBaseViewModel() { Id = x.Id, Title = x.VideoName, ViewsCount = x.ViewsCount,VideoPath= x.VideoPath });
            return await res.ToListAsync();
                
              
        }

		public async Task<IList<Domain.Entities.Videos.Video>> GetAllVideosAsync()
		{
			var res = _unitOfWork.Videos.GetAll().OrderBy(x => x.CategoryId).ThenBy(x=> x.Id);

			return await res.ToListAsync();
		}

		public async Task<VideoViewModel> GetAsync(long id)
        {
            var videoInfo = await _unitOfWork.Videos.FindByIdAsync(id);
            if (videoInfo is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Video not found");
            VideoViewModel videoViewModel = new VideoViewModel()
            {
                Id = videoInfo.Id,
                Title = videoInfo.VideoName,
                Description = videoInfo.VideoDescription,
                ViewsCount = videoInfo.ViewsCount
            };
            var file = new FileInfo("wwwroot/"+videoInfo.VideoPath);
             var bytes= await File.ReadAllBytesAsync(file.FullName);
            var base64 = Convert.ToBase64String(bytes);
             videoViewModel.VideoPath = String.Format("data:video;base64,{0}", base64);
            return videoViewModel;
        }
    }
}
