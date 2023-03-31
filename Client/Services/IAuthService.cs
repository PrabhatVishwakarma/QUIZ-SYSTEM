using Tool.Shared;
namespace Tool.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginViewModel loginModel);
        Task Logout();
    }
}
