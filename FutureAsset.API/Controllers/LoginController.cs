using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutureAsset.API.Infrastructure;
using FutureAsset.Model;
using FutureAsset.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FutureAsset.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserService _userService;

        public LoginController(IMemoryCache memoryCache, IUserService userService)
        {
            _memoryCache = memoryCache;
            _userService = userService;
        }

        [HttpPost]//Post

        public Response<bool> Login([FromBody] UserViewModel loginUser)
        {
            Response<bool> response = new() { Data = false };
            Response<UserViewModel> _response = _userService.Login(loginUser);
            if (_response.IsSuccess)
            {
                if (!_memoryCache.TryGetValue(CacheKeys.Login, out UserViewModel _loginUser))
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),// after one hour, erased from cache. 
                        Priority = CacheItemPriority.Normal
                    };
                    _memoryCache.Set(CacheKeys.Login, response.Data, cacheOptions);
                }
                response.Data = true;
            }

            return response;
            
        }

    }
}