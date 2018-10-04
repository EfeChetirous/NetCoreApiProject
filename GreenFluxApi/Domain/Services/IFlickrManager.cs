using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public interface IFlickrManager
    {
        Flickr GetInstance();
    }
}
