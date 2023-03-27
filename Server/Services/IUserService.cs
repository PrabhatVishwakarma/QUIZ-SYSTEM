
using Tool.Server.Model;

public interface IUserService
{

    Task<bool> Login(User user);
}