
using System;
using Tool.Server.Model;

public class UserService : IUserService
{
    private readonly IRepository<User> _user;

    public UserService(IRepository<User> user)
    {
        _user = user;
    }

    public async Task<bool> Login(User user)
    {
        User createdUser = await _user.CreateAsync(user);

        if (createdUser != null) return true; else return false;
    }
}

