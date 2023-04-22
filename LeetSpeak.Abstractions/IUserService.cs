using LeetSpeak.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Abstractions
{
    public interface IUserService
    {
        Task<LoginUserResponse> Login(LoginUserRequest loginUserRequest);
		Task<bool> IsUserLoggedIn(string token);

	}
}
