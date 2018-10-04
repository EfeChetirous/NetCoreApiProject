using GreenFluxApi.Common;
using GreenFluxApi.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxApi.Domain.Services
{
    public class RedisCacheService : IRedisCacheSerivice
    {
        private readonly IDistributedCache _redisCache;
        private readonly RedisSettingModel _redisSetting;
        public RedisCacheService(IDistributedCache redisCache, IOptions<RedisSettingModel> redisSetting)
        {
            _redisCache = redisCache;
            _redisSetting = redisSetting.Value;
        }
        public async void AddAsync<T>(string key, T value)
        {
            //Sets how long the cache entry can be inactive(e.g.not accessed) before it will be removed
            var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(_redisSetting.TimeoutValue));
            //Gets or sets an absolute expiration time, relative to now.
            //option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_redisSetting.TimeoutValue);

            await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(value), option);
        }

        public async void ClearAsync(string key)
        {
            await _redisCache.RemoveAsync(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string cacheResult = await _redisCache.GetStringAsync(key);
            if (string.IsNullOrWhiteSpace(cacheResult))
            {
                return null;
            }
            T result = JsonConvert.DeserializeObject<T>(cacheResult);
            return (T)result;
        }

        public async Task<List<T>> GetAll<T>(string key)
        {
            var cacheResult = await _redisCache.GetStringAsync(key);
            List<T> result = JsonConvert.DeserializeObject<List<T>>(cacheResult);
            return result;
        }
    }
}
