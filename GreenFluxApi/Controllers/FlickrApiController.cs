using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrNet;
using GreenFluxApi.Domain.Models;
using GreenFluxApi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GreenFluxApi.Controllers
{
    [Produces("application/json")]
    [Route("Flickr")]
    public class FlickrApiController : Controller
    {
        private IFlickrService _flickrService;
        private ICityService _cityService;
        private IDistributedCache _cache;
        private IRedisCacheSerivice _redisCacheService;
        public FlickrApiController(IDistributedCache cache, IFlickrService flickrService, ICityService cityService, IRedisCacheSerivice redisCacheService)
        {
            _cache = cache;
            _flickrService = flickrService;
            _cityService = cityService;
            _redisCacheService = redisCacheService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchRequestModel searchRqModel)
        {
            if (string.IsNullOrWhiteSpace(searchRqModel.Keyword))
            {
                return BadRequest("Keyword is a mandotary field.");
            }
            var photos = await _flickrService.SearchImage(searchRqModel);
            return Ok(photos);
        }

        [HttpPost("searchByRegion")]
        public async Task<IActionResult> searchByRegion([FromBody] SearchRequestModel searchRqModel)
        {
            if (searchRqModel.Latitude == 0 || searchRqModel.Longitude == 0)
            {
                return BadRequest("Longitude and Latitude are mandotary fields.");
            }
            var photos = await _flickrService.SearchWithinGeoRegionAsync(searchRqModel);
            return Ok(photos);
        }

        [HttpPost("SearchByRegionAndName")]
        public async Task<IActionResult> SearchByRegionAndName([FromBody] SearchRequestModel searchRqModel)
        {
            if (searchRqModel.Latitude == 0 || searchRqModel.Longitude == 0 || string.IsNullOrWhiteSpace(searchRqModel.Keyword))
            {
                return BadRequest("Longitude, Latitude and Keyword are mandotary fields.");
            }
            var photos = await _flickrService.SearchByRegionAndName(searchRqModel);
            return Ok(photos);
        }

        [HttpGet("SearchById/{PhotoId}/{RedisKey}")]
        public async Task<IActionResult> SearchById([FromRoute] string photoId, string redisKey)
        {
            if (string.IsNullOrWhiteSpace(photoId) || string.IsNullOrWhiteSpace(redisKey))
            {
                return BadRequest("photoId and redisKey are mandotary fields.");
            }
            var photos = await _flickrService.SearchByPhotoId(photoId, redisKey);
            return Ok(photos);
        }

        [HttpGet("GetPhotoInfoById/{PhotoId}")]
        public async Task<IActionResult> GetPhotoInfoById([FromRoute] string photoId)
        {
            if (string.IsNullOrWhiteSpace(photoId))
            {
                return BadRequest("photoId is a mandotary field.");
            }
            var photos = await _flickrService.GetPhotoInfoById(photoId);
            return Ok(photos);
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCities();
            return Ok(cities);
        }

        [HttpGet("ClearCacheByKey/{key}")]
        public IActionResult ClearCacheByKey([FromRoute] string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return BadRequest("key is a mandotary field.");
            }
            _redisCacheService.ClearAsync(key);
            return Ok();
        }
    }
}