using FutureAsset.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FutureAsset.API.Infrastructure
{
    public class BaseController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public BaseController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public UserViewModel CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }

        private UserViewModel GetCurrentUser()
        {
            var response = new UserViewModel();
            if (_memoryCache.TryGetValue(CacheKeys.Login, out UserViewModel loginUser))
            {
                response = loginUser;
            }
            return loginUser;
        }
    }
}
