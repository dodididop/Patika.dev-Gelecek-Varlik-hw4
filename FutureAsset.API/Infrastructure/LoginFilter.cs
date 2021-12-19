using FutureAsset.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace FutureAsset.API.Infrastructure
{
    public class LoginFilter : IActionFilter
    {
        private readonly IMemoryCache _memoryCache;

        public LoginFilter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_memoryCache.TryGetValue(CacheKeys.Login, out UserViewModel response))
            {
                context.Result = new BadRequestObjectResult("User is null");
            }
            return;
        }
    }
}
