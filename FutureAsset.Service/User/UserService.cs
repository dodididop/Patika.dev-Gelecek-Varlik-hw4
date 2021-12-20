using System;
using System.Linq;
using AutoMapper;
using FutureAsset.DB.Entities.DatabaseContext;
using FutureAsset.Model;

namespace FutureAsset.Service.User
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Response<bool> Create(UserViewModel newUser)
        {
            try
            {
                var user = _mapper.Map<FutureAsset.DB.Entities.User>(newUser);
                user.IsActive = true;
                user.IsDeleted = false;

                using (var srv = new FutureAssetDBContext())
                {
                    srv.User.Add(user);
                    srv.SaveChanges();
                    return new Response<bool>(true);
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false);
            }
        }

        public Response<UserViewModel> Login(UserViewModel loginUser)
        {
            Response<UserViewModel> result = new();
            try
            {
                using (var srv = new FutureAssetDBContext())
                {
                    var _data = srv.User.FirstOrDefault(a => a.UserName == loginUser.UserName &&
                    a.Password == loginUser.Password);
                    if (_data is not null)
                    {
                        result.IsSuccess = true;
                        result.Data = _mapper.Map<UserViewModel>(_data);
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
            }

            return result;
        }
    }
}

