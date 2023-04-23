using System;
using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Test.Mocks;
using LeetSpeak.Test.Mocks.Repositories;
using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LeetSpeak.Shared.Models;

namespace LeetSpeak.Test
{
	[TestFixture]
	public class UserServiceTests
	{
		private IUserService _userService;

		[SetUp]
		public void Setup()
		{
			ITokenService tokenService = new MockTokenService();
			IUserRepository userRepository = new MockUserRepository();
			_userService = new UserService(tokenService, userRepository);
		}

		[Test]
		public async Task Login_WithValidCredentials_ReturnsLoginUserResponseWithToken()
		{
			var loginUserRequest = new LoginUserRequest { UserName = "admin", Password = "admin" };

			var result = await _userService.Login(loginUserRequest);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsLoggedIn);
		}

		[Test]
		public async Task Login_WithInvalidCredentials_ThrowsException()
		{
			var loginUserRequest = new LoginUserRequest { UserName = "foo", Password = "bar" };

			Assert.ThrowsAsync<Exception>(() => _userService.Login(loginUserRequest));
		}

		[Test]
		public async Task IsUserLoggedIn_WithValidToken_ReturnsTrue()
		{
			var token = "valid-token";

			var result = await _userService.IsUserLoggedIn(token);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsUserLoggedIn_WithInvalidToken_ReturnsFalse()
		{
			var token = "invalid-token";

			var result = await _userService.IsUserLoggedIn(token);

			Assert.IsFalse(result);
		}
	}
}
