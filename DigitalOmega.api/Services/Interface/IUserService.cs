using DigitalOmega.api.Request;
using DigitalOmega.api.Response;

namespace DigitalOmega.api.Services.Interface
{
    public interface IUserService
    {
        Tuple<LoginResponse, bool, bool> AdminLogin(LoginRequest request);
        GetUsersResponse GetUsers(ListGeneralModel page);
        Task<bool> SaveUser(CreateUserRequest createUser, Guid userId);
        CreateUserRequest GetEditUser(Guid userId);
    }
}
