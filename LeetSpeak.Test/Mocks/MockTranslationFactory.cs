using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System;

namespace LeetSpeak.Test.Mocks
{
	public class MockTranslationFactory : ITranslationFactory
	{
		public Translation CreateTranslation(string text, string leet)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentNullException(nameof(text));
			}

			if (string.IsNullOrWhiteSpace(leet))
			{
				throw new ArgumentNullException(nameof(leet));
			}

			return new Translation
			{
				OriginalText = text,
				FormattedText = leet,
				CreatingDate = DateTime.UtcNow
			};
		}
	}
}
