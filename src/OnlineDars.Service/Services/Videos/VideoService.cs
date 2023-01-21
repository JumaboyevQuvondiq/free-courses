using OnlineDars.DataAccess.Interfaces;
using OnlineDars.Domain.Exceptions;
using OnlineDars.Service.Interfaces.Videos;
using OnlineDars.Service.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public Task<IList<VideoViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
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
                VideoPath = videoInfo.VideoPath,
                ViewsCount = videoInfo.ViewsCount
            };
            return videoViewModel;
        }
    }
}
