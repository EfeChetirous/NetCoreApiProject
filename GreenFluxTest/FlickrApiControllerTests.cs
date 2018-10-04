using GreenFluxApi.Controllers;
using GreenFluxApi.Domain.Models;
using GreenFluxApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GreenFluxTest
{
    public class FlickrApiControllerTests
    {
        private readonly FlickrApiController _flickrApiController;
        private readonly Mock<IFlickrService> _flickrServiceMock = new Mock<IFlickrService>();
        private readonly Mock<ICityService> _cityServiceMock = new Mock<ICityService>();
        private readonly Mock<IDistributedCache> _cache = new Mock<IDistributedCache>();
        private Mock<IRedisCacheSerivice> _redisCacheService = new Mock<IRedisCacheSerivice>();

        public FlickrApiControllerTests()
        {
            _flickrApiController = new FlickrApiController(_cache.Object, _flickrServiceMock.Object, _cityServiceMock.Object, _redisCacheService.Object);
        }

        [Fact]
        public async Task ShouldGetSearchResults()
        {
            SearchRequestModel searchRequestModel = new SearchRequestModel();
            searchRequestModel.Keyword = "sun";
            searchRequestModel.PageNumber = 3;
            searchRequestModel.PerPage = 10;
            var results = await _flickrApiController.Search(searchRequestModel);
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task ShouldGetSearchByRegionResults()
        {
            SearchRequestModel searchRequestModel = new SearchRequestModel();
            searchRequestModel.Latitude = 38.423733;
            searchRequestModel.Longitude = 27.142826;
            searchRequestModel.PageNumber = 3;
            searchRequestModel.PerPage = 10;

            var results = await _flickrApiController.searchByRegion(searchRequestModel);
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task ShouldGetSearchByRegionAndNameResults()
        {
            SearchRequestModel searchRequestModel = new SearchRequestModel();
            searchRequestModel.Latitude = 38.423733;
            searchRequestModel.Longitude = 27.142826;
            searchRequestModel.Keyword = "sun";
            searchRequestModel.PageNumber = 3;
            searchRequestModel.PerPage = 10;

            var results = await _flickrApiController.SearchByRegionAndName(searchRequestModel);
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task ShouldFetchGetSearchByIdResult()
        {
            var results = await _flickrApiController.SearchById("8211020303", "SearchImageResult");
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task ShouldFetchGetPhotoInfoByIdResult()
        {
            var results = await _flickrApiController.GetPhotoInfoById("8211020303");
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task ShouldFetchGetallCities()
        {
            var results = await _flickrApiController.GetAllCities();
            var objectResult = results as ObjectResult;
            Assert.NotNull(results);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }
        [Fact]
        public void ShouldClearCacheById()
        {
            var results = _flickrApiController.ClearCacheByKey("City");
            var objectResult = results as StatusCodeResult;
            Assert.Equal(200, objectResult.StatusCode);
        }
    }
}
