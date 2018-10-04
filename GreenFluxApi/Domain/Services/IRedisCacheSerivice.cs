using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public interface IRedisCacheSerivice
    {
        void AddAsync<T>(string key, T value);
        void ClearAsync(string key);
        Task<T> GetAsync<T>(string key) where T : class;
    }
}
