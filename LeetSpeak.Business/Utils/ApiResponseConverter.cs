using LeetSpeak.Shared.Constants;
using LeetSpeak.Shared.Models;
using Newtonsoft.Json;

namespace LeetSpeak.Business.Services
{
    public static class ApiResponseConverter
    {
        public static Translation ConvertToTranslation(ApiResponse apiResponse)
        {
            return new Translation
            {
                OriginalText = apiResponse?.Contents?.text,
                FormattedText = apiResponse?.Contents?.translated,
                CreatingDate = DateTime.Now,
                CreatingUser = "System" // Dilerseniz buradaki kullanıcı adını güncelleyebilirsiniz
            };
        }
		public static LeetSpeakResponse ConvertToLeetSpeakResponse(List<Translation> translations)
		{
			LeetSpeakResponse response = new LeetSpeakResponse();
			try
			{
				// translations listesini JSON formatına dönüştürerek ResponseMessage özelliğine atayın
				response.ResponseMessage = JsonConvert.SerializeObject(translations);
				response.HasError = false;
			}
			catch (Exception ex)
			{
				// Hata durumunda response nesnesini doldur
				response.ResponseMessage = "Çeviri işlemi sırasında bir hata oluştu: " + ex.Message;
				response.HasError = true;
			}

			return response;
		}

	}
}
