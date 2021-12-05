using DigitalOmega.api.Request;
using DigitalOmega.api.Response;

namespace DigitalOmega.api.Interface
{
    public interface IUsers
    {
        Tuple<LoginResponse, bool, bool> AdminLogin(LoginRequest request);
    }
}
