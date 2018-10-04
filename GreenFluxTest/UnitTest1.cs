using GreenFluxApi.Controllers;
using GreenFluxApi.Domain.Services;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using Xunit;

namespace GreenFluxTest
{
    public class UnitTest1
    {
        private readonly FlickrApiController _flickrApiController;
        private readonly Mock<IFlickrService> _flickrServiceMock;
        private readonly Mock<IDistributedCache> _cache;
        [Fact]
        public void Test1()
        {

        }
    }
}
