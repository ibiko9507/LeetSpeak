using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Constants;
using Newtonsoft.Json;
using UrlShortening.Shared.Models;

namespace LeetSpeak.Business.Services
{
    public class TranslateService : ITranslateService
    {
        #region Properties 


        #endregion


        public async Task<LeetSpeakResponse> ConvertOriginalTextToFormattedText(string originalText)
        {
            string? formattedText = string.Empty;
            bool hasError = false;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var requestContent = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("text", originalText),
                    new KeyValuePair<string, string>("api_key", ApiConstants.ApiKey)
                });

                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.ApiUrl, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                        formattedText = apiResponse?.Contents?.Translated;
                    }
                    else
                    {
                        formattedText = "";
                        hasError = true;
                    }
                }
            }
            catch (InvalidOperationException operationException)
            {
                hasError = true;
                formattedText = operationException.Message;
            }


            return new LeetSpeakResponse()
            {
                ResponseMessage = formattedText,
                HasError = hasError
            };
        }

       
    }
}