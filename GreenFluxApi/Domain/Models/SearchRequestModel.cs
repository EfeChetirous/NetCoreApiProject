using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Models
{
    public class SearchRequestModel
    {
        public string Keyword { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int PageNumber { get; set; }
        public int PerPage { get; set; }
    }
}
