using LeetSpeak.Abstractions;
using LeetSpeak.DataAccess.Context;
using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

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

		public async Task<List<Translation>> GetTranslation()
		{
			var translations = new List<Translation>();

			using (var dbContext = new LeetSpeakDbContext(_dbContextOptions))
			{
				await dbContext.Database.OpenConnectionAsync();
				using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
				{
					cmd.CommandText = "get_translations";
					cmd.CommandType = CommandType.StoredProcedure;

					using (var reader = await cmd.ExecuteReaderAsync())
					{
						while (await reader.ReadAsync())
						{
							var translation = new Translation
							{
								Id = reader.GetInt32(0),
								OriginalText = reader.GetString(1),
								FormattedText = reader.GetString(2),
								CreatingDate = reader.GetDateTime(3),
								CreatingUser = reader.GetString(4)
							};

							translations.Add(translation);
						}
					}
				}
				await dbContext.Database.CloseConnectionAsync();
			}

			return translations;
		}




		public void Dispose()
		{
			//
		}

	}
}