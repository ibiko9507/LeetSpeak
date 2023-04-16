using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared;
using Microsoft.AspNetCore.Mvc;
using UrlShortening.Shared.Models;

namespace LeetSpeak.Api
{
    [ApiController]
    [Route("translate")]
    public class TranslateController : ControllerBase
    {
        #region Properties
        private readonly ITranslateService _translateService;
        #endregion

        private readonly ILogger<TranslateController> _logger;

        public TranslateController(
            ILogger<TranslateController> logger,
            ITranslateService translateService
            )
        {
            _logger = logger;
            _translateService = translateService;
        }

        [HttpGet(Name = "ConvertOriginalTextToFormattedText")]
        public async Task<IActionResult> ConvertOriginalTextToFormattedText(string originalText)
        {
            return await _translateService.ConvertOriginalTextToFormattedText(originalText).GenerateResponse();
        }

		[HttpGet(Name = "ConvertOriginalTextToFormattedText")]
		public async Task<IActionResult> GetTranslations(string originalText)
		{
            return Ok("");
			//return await _translateService.GetTranslations(originalText).GenerateResponse();
		}
	}
}