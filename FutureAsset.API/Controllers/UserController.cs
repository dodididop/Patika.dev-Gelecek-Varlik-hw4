using AutoMapper;
using FutureAsset.API.Infrastructure;
using FutureAsset.Model;
using FutureAsset.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FutureAsset.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private static readonly IMemoryCache memoryCache;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        

        public UserController(IMapper mapper, IUserService userService) : base(memoryCache)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]

        public Response<bool> Create([FromBody] UserViewModel request)
        {
            return _userService.Create(request);
        }
    }
}