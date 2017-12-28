namespace Bolt.Web.Services
{
    using System;

    using Microsoft.Extensions.Caching.Memory;

    public class CookieCachingService
    {
        private readonly IMemoryCache _memoryCache;

        public CookieCachingService(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        public string Get(string key) => this._memoryCache.Get<string>(key);

        public void Set(string key, string value, int? expireTimeMinutes) => this._memoryCache.Set(key, value, DateTimeOffset.UtcNow.AddMinutes(expireTimeMinutes ?? 30));

        public void Remove(string key) => this._memoryCache.Remove(key);
    }
}
