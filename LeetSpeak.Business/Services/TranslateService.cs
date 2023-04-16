using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Constants;
using Newtonsoft.Json;
using UrlShortening.Shared.Models;

namespace LeetSpeak.Business.Services
{
	public class TranslateService : ITranslateService
	{
		#region Properties 

		ITranslateRepository _translateRepository;

		#endregion

		public TranslateService(ITranslateRepository translateRepository)
		{
			_translateRepository = translateRepository;
		}

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

						var translation = ApiResponseConverter.ConvertToTranslation(apiResponse);
						_translateRepository.AddTranslation(translation);
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

		public async Task<LeetSpeakResponse> GetTranslations()
		{
			string? formattedText = string.Empty;
			bool hasError = false;
			try
			{
				var translations = await _translateRepository.GetTranslation();
				return ApiResponseConverter.ConvertToLeetSpeakResponse(translations);

			}
			catch(Exception ex)
			{
				hasError = true;
				formattedText = ex.Message;
			}

			return new LeetSpeakResponse()
			{
				ResponseMessage = formattedText,
				HasError = hasError
			};
		}
	}
}