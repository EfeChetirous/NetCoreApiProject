using FlickrNet;
using GreenFluxApi.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public class FlickrManager : IFlickrManager
    {
        private readonly FlickrModel _flickrModel;
        public FlickrManager(IOptions<FlickrModel> flickrModel)
        {
            _flickrModel = flickrModel.Value;
        }

        public Flickr GetInstance()
        {
            return new Flickr(_flickrModel.ApiKey, _flickrModel.ApiSecret);
        }
    }
}
