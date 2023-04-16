using LeetSpeak.Abstractions;
using LeetSpeak.DataAccess.Context;
using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LeetSpeak.DataAccess.Repositories
{
    public class TranslateRepository : ITranslateRepository
    {
        private readonly DbContextOptions<LeetSpeakDbContext> _dbContextOptions;

        public TranslateRepository(DbContextOptions<LeetSpeakDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task AddTranslation(Translation translation)
        {
            using (var dbContext = new LeetSpeakDbContext(_dbContextOptions))
            {
                await dbContext.Translations.AddAsync(translation);
                await dbContext.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            //
        }

    }
}