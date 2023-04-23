using LeetSpeak.Shared.Models;

namespace LeetSpeak.Abstractions
{
	public interface ITranslateService
	{
		Task<LeetSpeakResponse> GetTranslations();
		Task<LeetSpeakResponse> ConvertOriginalTextToFormattedText(string originalText);
	}
}