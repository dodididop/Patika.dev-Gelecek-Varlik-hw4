using AutoMapper;
using FutureAsset.Model;
using FutureAsset.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace FutureAsset.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]

        public Response<bool> Create([FromBody] UserViewModel request)
        {
            return _userService.Create(request);
        }
    }
}