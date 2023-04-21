using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public UserService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserResponse> Login(LoginUserRequest loginUserRequest)
        {
            if (!(loginUserRequest.UserName == "admin" && loginUserRequest.Password == "admin"))
                throw new Exception("UserNotFound"); //Make sub exception classes

            LoginUserResponse loginUserResponse = new LoginUserResponse()
            {
                User = new User() { UserName = loginUserRequest.UserName },
                Token = _tokenService.CreateAccessToken(10), // todo : Ön yüze Sign in ekle. Default page sign in olsun
                IsLoggedIn = true
            };

            await _userRepository.AddUserToken(loginUserResponse);

            return loginUserResponse; ;
        }

		public async Task<bool> IsUserLoggedIn()
		{
            return false;
		}
	}
}
