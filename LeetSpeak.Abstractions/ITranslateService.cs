using UrlShortening.Shared.Models;

namespace LeetSpeak.Abstractions
{
    public interface ITranslateService
    {
        Task<LeetSpeakResponse> ConvertOriginalTextToFormattedText(string originalUrl);
    }
}