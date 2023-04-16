using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;

namespace LeetSpeak.Business.Services
{
    public static class ApiResponseConverter
    {
        public static Translation ConvertToTranslation(ApiResponse apiResponse)
        {
            return new Translation
            {
                //OriginalText = apiResponse?.Contents?.Or,
                FormattedText = apiResponse?.Contents?.Translated,
                CreatingDate = DateTime.Now,
                CreatingUser = "System" // Dilerseniz buradaki kullanıcı adını güncelleyebilirsiniz
            };
        }
    }
}
