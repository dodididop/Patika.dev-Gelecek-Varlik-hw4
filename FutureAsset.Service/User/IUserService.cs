using FutureAsset.Model;

namespace FutureAsset.Service.User
{
    public interface IUserService
    {
        public Response<bool> Create(UserViewModel newUser);
        public Response<UserViewModel> Login(UserViewModel loginUser);
    }
}
