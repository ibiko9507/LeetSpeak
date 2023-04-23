using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetSpeak.Test.Mocks.Repositories
{
	public class MockUserRepository : IUserRepository
	{
		private readonly List<TokenResponse> _userTokens = new List<TokenResponse>();

		public Task AddUserToken(LoginUserResponse loginUserResponse)
		{
			_userTokens.Add(new TokenResponse { AccessToken = loginUserResponse.Token.AccessToken, ExpirationDate = loginUserResponse.Token.ExpirationDate });

			return Task.CompletedTask;
		}

		public Task<TokenResponse> GetUserToken(string token)
		{
			var userToken = _userTokens.FirstOrDefault(ut => ut.AccessToken == token);

			return Task.FromResult(userToken);
		}

		public Task RemoveUserToken(string token)
		{
			var userToken = _userTokens.FirstOrDefault(ut => ut.AccessToken == token);
			if (userToken != null)
			{
				_userTokens.Remove(userToken);
			}

			return Task.CompletedTask;
		}
	}
}
