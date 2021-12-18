using FutureAsset.Model;

namespace FutureAsset.Service.User
{
    public interface IUserService
    {
        public Response<bool> Create(UserViewModel newUser);
    }
}
