using LeetSpeak.Abstractions;

namespace LeetSpeak.Business.Services
{
    public class TranslateService : ITranslateService
    {
        #region Properties 


        #endregion
        public async Task<string> AddTranslation(string originalText)
        {
            string formattedText = ConvertOriginalTextToFormattedText(originalText);
            return formattedText;
        }

        private string ConvertOriginalTextToFormattedText(string originalText)
        {
            return string.Empty;
        }
    }
}