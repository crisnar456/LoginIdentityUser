using LoginIdentityUser.Data.Entities;
using LoginIdentityUser.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginIdentityUser.Helpers
{
    public interface IUserHelper
    {
        Task<SignInResult> LoginAsync(LoginDto model);

        Task LogoutAsync();

        Task<User> AddUser(AddUserDto view);

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
