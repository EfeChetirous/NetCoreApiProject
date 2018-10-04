using FlickrNet;
using GreenFluxApi.Common;
using GreenFluxApi.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StackExchange.Redis;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace GreenFluxApi.Domain.Services
{
    public class FlickrService : IFlickrService
    {
        private IDistributedCache _redisCache;
        private IFlickrManager _flickrManager;
        private readonly FlickrModel _flickrModel;

        public FlickrService(IDistributedCache redisCache, IOptions<FlickrModel> flickrModel, IFlickrManager flickrManager)
        {
            _redisCache = redisCache;
            _flickrModel = flickrModel.Value;
            _flickrManager = flickrManager;
        }

        public async Task<PhotoCollection> SearchImage(SearchRequestModel searchRqModel)
        {
            try
            {
                var photos = await CallFlickrApi(searchRqModel);
                return photos;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ErrorMessage, ex.Message));
            }
        }

        public async Task<PhotoCollection> SearchWithinGeoRegionAsync(SearchRequestModel searchRqModel)
        {
            try
            {
                var photos = await CallFlickrApi(searchRqModel);
                return photos;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ErrorMessage, ex.Message));
            }
        }

        public async Task<PhotoCollection> SearchByRegionAndName(SearchRequestModel searchRqModel)
        {
            try
            {
                var photos = await CallFlickrApi(searchRqModel);
                return photos;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ErrorMessage, ex.Message));

            }
        }
        public async Task<PhotoModel> GetPhotoInfoById(string photoId)
        {
            try
            {
                Flickr flickrManager = _flickrManager.GetInstance();
                string getInfoUrl = string.Format(Constants.GetInfoUrlBase, flickrManager.ApiKey, photoId);
                HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(getInfoUrl);
                timeLineRequest.Method = "Get";
                WebResponse timeLineResponse = await timeLineRequest.GetResponseAsync();
                var timeLineJson = string.Empty;
                PhotoModel photo = new PhotoModel();

                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        timeLineJson = await reader.ReadToEndAsync();
                        XmlSerializer serializer = new XmlSerializer(typeof(GreenFluxApi.Domain.Models.PhotoModel));
                        MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(timeLineJson));
                        photo = (PhotoModel)serializer.Deserialize(memStream);
                    }
                }
                return photo;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ErrorMessage, ex.Message));
            }
        }

        public async Task<FlickrNet.Photo> SearchByPhotoId(string photoId, string redisKey)
        {
            try
            {
                var cacheResult = await _redisCache.GetStringAsync(redisKey);
                if (!string.IsNullOrWhiteSpace(cacheResult))
                {
                    PhotoCollection photoCollections = JsonConvert.DeserializeObject<PhotoCollection>(cacheResult);
                    return photoCollections.FirstOrDefault(x => x.PhotoId.Equals(photoId.Trim()));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Constants.ErrorMessage, ex.Message));
            }
        }

        private async Task<PhotoCollection> CallFlickrApi(SearchRequestModel searchRqModel)
        {
            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions();
            Flickr flickrManager = _flickrManager.GetInstance();
            photoSearchOptions.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            photoSearchOptions.SortOrder = PhotoSearchSortOrder.Relevance;
            photoSearchOptions.Tags = searchRqModel.Keyword;
            photoSearchOptions.Longitude = searchRqModel.Longitude;
            photoSearchOptions.Latitude = searchRqModel.Latitude;
            photoSearchOptions.Page = searchRqModel.PageNumber;
            photoSearchOptions.PerPage = searchRqModel.PerPage;
            PhotoCollection photos = flickrManager.PhotosSearch(photoSearchOptions);
            return photos;
        }

    }
}
