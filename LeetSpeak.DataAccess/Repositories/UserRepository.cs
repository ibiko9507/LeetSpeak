using LeetSpeak.Abstractions;
using LeetSpeak.DataAccess.Context;
using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<LeetSpeakDbContext> _dbContextOptions;

        public UserRepository(DbContextOptions<LeetSpeakDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
        public async Task AddUserToken(LoginUserResponse userResponse)
        {
            using (var dbContext = new LeetSpeakDbContext(_dbContextOptions))
            {
                await dbContext.Database.ExecuteSqlRawAsync(
                    "CALL add_usertoken({0}, {1}, {2})",
                    userResponse.User.UserName,
                    userResponse.Token.AccessToken,
                    userResponse.Token.ExpirationDate);
            }
        }
    }
}
