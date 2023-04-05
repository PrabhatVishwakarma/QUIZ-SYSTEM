using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tool.Shared;

namespace Tool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });
            }
            if (!await _roleManager.RoleExistsAsync("USER"))
            {
                var role = new IdentityRole("USER");
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await _roleManager.CreateAsync(role);
            }

            if (newUser.Email.ToLower().Contains("admin"))
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(newUser, "User");
            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}
