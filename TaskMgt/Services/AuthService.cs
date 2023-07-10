using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMgt.DTOs;
using TaskMgt.Models;

namespace TaskMgt.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Register(RegisterDto register)
        {
            var existingUser = _userManager.FindByEmailAsync(register.EmailAddress);
            if (existingUser != null)
                throw new Exception("User with email address exists");

                ApplicationUser newUser = new()
                {
                    Email = register.EmailAddress,
                    UserName = register.Username,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(newUser, register.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return "User created";
                }
                else
                    return "An error occures";



        }
    }
}
