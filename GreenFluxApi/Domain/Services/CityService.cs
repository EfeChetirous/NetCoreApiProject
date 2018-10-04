using GreenFluxApi.Common;
using GreenFluxApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly IRedisCacheSerivice _redisCacheService;
        public CityService(IRedisCacheSerivice redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }
        public async Task<List<CityModel>> GetAllCities()
        {
            List<CityModel> cities = await _redisCacheService.GetAsync<List<CityModel>>(Constants.City);
            if (cities == null)
            {
                cities = GetAllCitiesPersistenceData();
                if (cities != null)
                {
                    _redisCacheService.AddAsync(Constants.City, cities);
                }                
            }
            return cities;
        }

        /// <summary>
        /// These are persistence data collection.
        /// We can think of it that we fetch data from from the database.
        /// </summary>
        /// <returns></returns>
        private List<CityModel> GetAllCitiesPersistenceData()
        {
            return new List<CityModel>()
            { new CityModel() { Id = 1, Name = "Utrecht" },
            { new CityModel() { Id = 2, Name = "Amsterdam" } },
            { new CityModel() { Id = 3, Name = "Eindhoven" } },
            { new CityModel() { Id = 5, Name = "Ankara" } },
            { new CityModel() { Id = 6, Name = "İstanbul" } }};
        }
    }
}
