using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System;

namespace LeetSpeak.Test.Mocks
{
	public class MockTokenService : ITokenService
	{
		public TokenResponse CreateAccessToken(int min)
		{
			var token = "'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2ODIxODAxMzMsImV4cCI6MTY4MjE4MDczMywiaXNzIjoid3d3LkxlZXRTcGVhay5jb20iLCJhdWQiOiJ3d3cuTGVldFNwZWFrLmNvbSJ9.u4SSZc_TEO_k-uncJjsuaz4mJScV85Idqkn2k8aqT04'";
			var expires = DateTime.UtcNow.AddMinutes(min);
			return new TokenResponse { AccessToken = token, ExpirationDate = expires };
		}
	}
}
