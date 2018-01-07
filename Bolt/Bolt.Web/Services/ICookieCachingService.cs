namespace Bolt.Web.Services
{
    public interface ICookieCachingService
    {
        string Get(string key);

        void Remove(string key);

        void Set(string key, string value, int? expireTimeMinutes);
    }
}