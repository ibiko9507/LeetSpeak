using LeetSpeak.Abstractions;
using LeetSpeak.DataAccess.Context;
using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

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
				await dbContext.Database.ExecuteSqlRawAsync(
					"CALL add_translation({0}, {1}, {2})",
					translation.OriginalText,
					translation.FormattedText,
					translation.CreatingUser);
			}
		}

		public async Task<List<Translation>> GetTranslation()
		{
			var translations = new List<Translation>();
			using (var dbContext = new LeetSpeakDbContext(_dbContextOptions))
			{
				translations = dbContext.Set<Translation>()
					.FromSqlInterpolated($"CALL Get_Translations")
					.ToList();
			}

			return translations;
		}

		public void Dispose()
		{
			//
		}

	}
}