using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;

namespace LeetSpeak.DataAccess.Context
{
    public class LeetSpeakDbContext : DbContext
    {
        public LeetSpeakDbContext(DbContextOptions<LeetSpeakDbContext> options) : base(options)
        {

        }

        public DbSet<Translation> Translations { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfiguration configuration = new ConfigurationBuilder()
					.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					.Build();

				string connectionString = configuration.GetConnectionString("MySqlConnection");
				optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))); // MySQL sürümünüzü burada belirtin
				optionsBuilder.EnableSensitiveDataLogging();
			}
		}


	}
}
