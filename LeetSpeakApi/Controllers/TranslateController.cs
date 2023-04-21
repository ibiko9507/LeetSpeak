using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared;
using Microsoft.AspNetCore.Mvc;
using LeetSpeak.Shared.Models;

namespace LeetSpeak.Api
{
    [ApiController]
    [Route("translate")]
    public class TranslateController : ControllerBase
    {
        #region Properties
        private readonly ITranslateService _translateService;
        private readonly ILogger<TranslateController> _logger;
        #endregion


        public TranslateController(
            ILogger<TranslateController> logger,
            ITranslateService translateService
            )
        {
            _logger = logger;
            _translateService = translateService;
        }

        [HttpGet("ConvertOriginalTextToFormattedText")]
        public async Task<IActionResult> ConvertOriginalTextToFormattedText(string originalText)
        {
            return await _translateService.ConvertOriginalTextToFormattedText(originalText).GenerateResponse();
        }

        [HttpGet("GetTranslations")]
        public async Task<IActionResult> GetTranslations()
        {
            return await _translateService.GetTranslations().GenerateResponse();
        }
    }
}