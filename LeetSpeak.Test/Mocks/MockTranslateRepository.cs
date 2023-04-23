using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Test.Mocks
{
	public class MockTranslateRepository : ITranslateRepository
	{
		private readonly List<Translation> _translations = new List<Translation>();

		public async Task AddTranslation(Translation translation)
		{
			if (translation == null)
			{
				throw new ArgumentNullException(nameof(translation));
			}

			_translations.Add(translation);
			await Task.CompletedTask;
		}

		public async Task<List<Translation>> GetTranslation()
		{
			await Task.CompletedTask;
			return _translations.ToList();
		}

		public void Dispose()
		{

		}
	}
}
