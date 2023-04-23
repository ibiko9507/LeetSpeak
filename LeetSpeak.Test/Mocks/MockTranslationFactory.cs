using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using System;

namespace LeetSpeak.Test.Mocks
{
	public class MockTranslationFactory : ITranslationFactory
	{
		public Translation CreateTranslation(string text, string leet = null)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentNullException(nameof(text));
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
