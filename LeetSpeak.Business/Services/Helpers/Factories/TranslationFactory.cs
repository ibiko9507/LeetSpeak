using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LeetSpeak.Business.Services.Helpers.Factories
{
	public class TranslationFactory : ITranslationFactory
	{
		public Translation CreateTranslation(string originalText, string formattedText = null)
		{
			return new Translation
			{
				OriginalText = originalText,
				FormattedText = formattedText,
				CreatingDate = DateTime.Now,
				CreatingUser = "" // after authantication

			};
		}
	}
}
