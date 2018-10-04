using GreenFluxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public interface ICityService
    {
        Task<List<CityModel>> GetAllCities();
    }
}
