using LeetSpeak.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.DataAccess.Context
{
    public class LeetSpeakDbContext : DbContext
    {
        public LeetSpeakDbContext(DbContextOptions<LeetSpeakDbContext> options) : base(options)
        {

        }

        public DbSet<Translation> Translations { get; set; }

        // Diğer DbSet'ler ve model sınıfları buraya eklenir
    }
}
