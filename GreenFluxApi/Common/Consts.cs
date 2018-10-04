using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Common
{
    public struct Constants
    {
        public const string ErrorMessage = "An error has been occurred. Exception details: {0}";
        public const string GetInfoUrlBase = "https://api.flickr.com/services/rest/?method=flickr.photos.getInfo&api_key={0}&photo_id={1}&format=rest";

        public const string SearchImageResult = "SearchImageResult";
        public const string SearchWithinGeoRegionResult = "SearchWithinGeoRegionResult";
        public const string SearchByRegionAndNameResult = "SearchByRegionAndNameResult";

        public const string City = "City";
        
    }
}
