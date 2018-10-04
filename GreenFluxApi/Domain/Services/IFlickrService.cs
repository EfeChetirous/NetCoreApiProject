using FlickrNet;
using GreenFluxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public interface IFlickrService
    {
        Task<PhotoCollection> SearchImage(SearchRequestModel searchRqModel);
        Task<PhotoCollection> SearchWithinGeoRegionAsync(SearchRequestModel searchRqModel);
        Task<PhotoCollection> SearchByRegionAndName(SearchRequestModel searchRqModel);
        Task<FlickrNet.Photo> SearchByPhotoId(string photoId, string redisKey);
        Task<PhotoModel> GetPhotoInfoById(string photoId);
    }
}
