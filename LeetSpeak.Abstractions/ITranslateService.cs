namespace LeetSpeak.Abstractions
{
    public interface ITranslateService
    {
        Task<string> AddTranslation(string originalUrl);
    }
}